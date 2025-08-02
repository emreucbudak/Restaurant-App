using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Queries.GetAllQueries
{
    public class GetAllRestaurantCommandResponse
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public int RestaurantCaseId { get; set; }
        public string RestaurantCaseName { get; set; }
    }
}
