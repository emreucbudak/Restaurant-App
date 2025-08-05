using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Auth.Command.Register
{
    public class RegisterCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       public string Role { get; set; }
        public int RestaurantId { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
