using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantDashboardApi.Application.Features.CQRS.Auth.Command.Login;
using RestaurantDashboardApi.Application.Features.CQRS.Auth.Command.RefreshToken;
using RestaurantDashboardApi.Application.Features.CQRS.Auth.Command.Register;
using RestaurantDashboardApi.Application.Features.CQRS.Auth.Command.Revoke;
using RestaurantDashboardApi.Application.Features.CQRS.Auth.Command.RevokeAll;

namespace RestaurantDashboardApi.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            await mediator.Send(new RevokeAllCommandRequest());
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}

