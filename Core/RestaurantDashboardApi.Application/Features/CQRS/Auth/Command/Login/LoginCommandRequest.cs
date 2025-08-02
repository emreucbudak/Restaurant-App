using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Auth.Command.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        [DefaultValue("emreucbudak12@gmail.com")]
        public string Email { get; set; }
        [DefaultValue("emreucbudak")]
        public string Password { get; set; }
    }
}
