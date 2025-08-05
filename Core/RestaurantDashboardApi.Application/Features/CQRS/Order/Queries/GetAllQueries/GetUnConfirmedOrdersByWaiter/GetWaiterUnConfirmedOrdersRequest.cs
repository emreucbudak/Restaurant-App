using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetAllQueries.GetUnConfirmedOrdersByWaiter
{
    public class GetWaiterUnConfirmedOrdersRequest : IRequest<IList<GetWaiterUnConfirmedOrdersResponse>>
    {
        public int WaiterId { get; set; }
        public int RestaurantId { get; set; }
    }
}
