using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Command.CreateCommand
{
    public class OrderItemCreateRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
    }
}
