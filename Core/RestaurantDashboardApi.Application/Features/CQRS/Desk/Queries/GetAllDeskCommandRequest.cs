using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Desk.Queries
{
    public class GetAllDeskCommandRequest : IRequest<IList<GetAllDeskCommandResponse>>
    {
        public int RestaurantId { get; set; }
    }
}
