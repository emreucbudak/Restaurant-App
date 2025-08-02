using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Waiter.Queries
{
    public class GetAllWaiterCommandRequest : IRequest<IList<GetAllWaiterCommandResponse>>
    {
        public int RestaurantId { get; set; }
    }
}
