using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Waiter.Command.UpdateCommand.WaiterWorkStatusUpdate
{
    public class UpdateWaiterWorkStatusRequest : IRequest
    {
        public string Email { get; set; }
    }
}
