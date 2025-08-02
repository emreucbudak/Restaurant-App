using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantDashboardApi.Application.Bases;
using RestaurantDashboardApi.Application.Features.CQRS.Auth.Command.Register.Extensions;
using RestaurantDashboardApi.Application.Features.CQRS.Auth.Rules;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Common;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Auth.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;
        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            unit = unitOfWork;
        }
        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));


            User user = mapper.Map<User>(request);

            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();
            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync(request.Role))
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = request.Role,
                        NormalizedName = request.Role.ToUpper(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });

                await userManager.AddToRoleAsync(user, request.Role);
            }
            request.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password);
            var (entity, entityType) = EntityFactory.CreateEntity(request.Role, request.Name, request.Surname, request.Email, request.Password);
            var interfaceType = typeof(IUnitOfWork);
            var methodInfo = interfaceType.GetMethod("GetWriteRepository");
            if (methodInfo == null)
                throw new InvalidOperationException("GetWriteRepository metodu bulunamadı.");

            var genericMethod = methodInfo.MakeGenericMethod(entityType);
            var repository = genericMethod.Invoke(unit, null);
            if (repository == null)
                throw new InvalidOperationException("Repository nesnesi alınamadı.");

            var addAsyncMethod = repository.GetType().GetMethod("AddAsync");
            if (addAsyncMethod == null)
                throw new InvalidOperationException("AddAsync metodu bulunamadı.");

            var task = (Task)addAsyncMethod.Invoke(repository, new object[] { entity });
            await task;


            await unit.SaveAsync();



            return Unit.Value;
        }
    }
}
