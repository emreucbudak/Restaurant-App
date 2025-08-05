using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Command.UpdateCommand.UpdateOrderStaus
{
    public class UpdateOrderStatusRequest : IRequest
    {
        public int OrderId { get; set; }
 
    }
}
