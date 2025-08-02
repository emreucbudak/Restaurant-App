using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Queries.GetAllQueries
{
    public class GetAllRestaurantCommandRequest : IRequest<IList<GetAllRestaurantCommandResponse>>
    {
    }
}
