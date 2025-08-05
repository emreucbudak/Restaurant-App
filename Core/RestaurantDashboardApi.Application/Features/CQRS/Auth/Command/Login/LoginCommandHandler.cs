using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantDashboardApi.Application.Features.CQRS.Auth.Rules;
using RestaurantDashboardApi.Application.Interfaces.TokenServices;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Common;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Auth.Command.Login
{
    public class LoginCommandHandler :  IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;
        private readonly AuthRules authRules;
        private readonly IUnitOfWork unitOfWork;

        public LoginCommandHandler(UserManager<User> userManager, IConfiguration configuration, ITokenService tokenService, AuthRules authRules, IMapper mapper, IUnitOfWork uunitOfWork) 
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.authRules = authRules;
            unitOfWork = uunitOfWork;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);
            bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password);

            await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

            IList<string> roles = await userManager.GetRolesAsync(user);
            string role = roles.FirstOrDefault();

            object roleAuthor = role switch
            {
                "Waiter" => await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Waiter>()
                                    .GetByExpression(false, b => b.Email == request.Email)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(),

                "RestaurantCase" => await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.RestaurantCase>()
                                        .GetByExpression(false, b => b.Email == request.Email)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(),

                _ => null
            };
            int? resId = roleAuthor is RestaurantDashboardApi.Domain.Entities.Waiter w ? w.RestaurantId
                         : roleAuthor is RestaurantDashboardApi.Domain.Entities.RestaurantCase r ? r.RestaurantId
                         : null;
            int? userId = roleAuthor is RestaurantDashboardApi.Domain.Entities.Waiter t ? t.Id
             : roleAuthor is RestaurantDashboardApi.Domain.Entities.RestaurantCase y ? y.Id
             : null;
            JwtSecurityToken token = await tokenService.CreateToken(user, roles);
            string refreshToken = tokenService.GenerateRefreshToken();

            _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            string _token = new JwtSecurityTokenHandler().WriteToken(token);

            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);


            return new()
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo,
                RestaurantId = resId,
                UserId = userId,
            };

        }
    }

}
