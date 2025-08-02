using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Command.UpdateCommand
{
    public class UpdateOrderCommandRequest : IRequest
    {
        public int OrderId { get; set; }
        public int TotalPrice { get; set; }

        public int OrderStatusId { get; set; }
        public ICollection<RestaurantDashboardApi.Domain.Entities.OrderItem>? Items { get; set; }
    }
}
