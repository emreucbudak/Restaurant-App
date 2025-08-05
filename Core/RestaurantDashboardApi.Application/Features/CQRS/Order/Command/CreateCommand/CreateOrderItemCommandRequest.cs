using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Command.CreateCommand
{
    public class CreateOrderItemCommandRequest : IRequest
    {
        public int TotalPrice { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public int WaiterId {  get; set; }
        public ICollection<OrderItemCreateRequest> Items { get; set; }
        public int DeskId { get; set; }
    }
}
