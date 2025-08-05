using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetAllQueries.GetUnConfirmedOrdersByWaiter
{
    public class ProductInfos
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
