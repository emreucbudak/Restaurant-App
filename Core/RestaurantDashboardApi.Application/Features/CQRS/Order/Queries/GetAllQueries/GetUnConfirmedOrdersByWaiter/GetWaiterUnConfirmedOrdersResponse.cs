using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetAllQueries.GetUnConfirmedOrdersByWaiter
{
    public class GetWaiterUnConfirmedOrdersResponse
    {
        public int OrderId { get; set; }
        public int TotalPrice { get; set; }
        public string DeskName { get; set; }
        public string? OrderNote { get; set; }
        public ICollection<ProductInfos> OrderItems { get; set; }
        public string OrderStatus { get; set; } 
       
    }
}
