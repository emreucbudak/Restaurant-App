using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Command.UpdateCommand.UpdateStatusOrderRequest
{
    public class UpdateStatusRequest : IRequest
    {
        public int OrderId { get; set; }
        public int NewStatus { get; set; }
    }
}
