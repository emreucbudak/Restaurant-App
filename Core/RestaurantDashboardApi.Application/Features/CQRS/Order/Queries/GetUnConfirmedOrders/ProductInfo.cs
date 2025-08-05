using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetUnConfirmedOrders
{
    public class ProductInfo
    {
        public string ProductName { get; set; }
        public int Quentity { get; set; }
        public int Price { get; set; }
    }
}
