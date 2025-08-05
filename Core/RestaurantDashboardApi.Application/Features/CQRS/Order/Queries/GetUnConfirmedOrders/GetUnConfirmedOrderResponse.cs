using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetUnConfirmedOrders
{
    public class GetUnConfirmedOrderResponse
    {
        public int OrderId { get; set; }    
        public int TotalPrice { get; set; }
        public string DeskName { get; set; }
        public string? OrderNote { get; set; }
        public ICollection<ProductInfo> OrderItems { get; set; }
        public string WaiterName { get; set; }
        public string Status { get; set; }
    }
}
