using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetUnConfirmedOrders
{
    public class GetUnConfirmedOrdersRequest : IRequest<IList<GetUnConfirmedOrderResponse>>
    {
        public int RestaurantId { get; set; }

    }
}
