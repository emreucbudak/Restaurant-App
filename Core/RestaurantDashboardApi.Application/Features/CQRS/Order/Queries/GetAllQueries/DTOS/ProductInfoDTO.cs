using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetAllQueries.DTOS
{
    public class ProductInfoDTO
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
    }

}
