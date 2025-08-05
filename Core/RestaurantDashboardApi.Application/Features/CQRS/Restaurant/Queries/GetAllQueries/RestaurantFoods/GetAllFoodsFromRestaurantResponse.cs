using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Queries.GetAllQueries.RestaurantFoods
{
    public class GetAllFoodsFromRestaurantResponse
    {
        public IList<RestaurantDashboardApi.Domain.Entities.Product> Products { get; set; }
        public IList<string> Categories { get; set; }
    }

}
