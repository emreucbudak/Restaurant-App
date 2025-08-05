using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Queries.GetAllQueries.RestaurantFoods
{
    public class GetAllFoodsFromRestaurantRequest : IRequest<IList<GetAllFoodsFromRestaurantResponse>>
    {
        public int Id { get; set; }
    }
}
