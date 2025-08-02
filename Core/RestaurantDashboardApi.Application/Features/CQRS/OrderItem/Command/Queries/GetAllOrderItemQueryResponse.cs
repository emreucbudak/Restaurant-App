using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.OrderItem.Command.Queries
{
    public class GetAllOrderItemQueryResponse
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public string DeskName  { get; set; }
        public string ProductName   { get; set; }

    }
}
