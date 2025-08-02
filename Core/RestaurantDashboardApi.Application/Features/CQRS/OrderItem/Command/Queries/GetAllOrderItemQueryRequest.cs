using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.OrderItem.Command.Queries
{
    public class GetAllOrderItemQueryRequest : IRequest<IList<GetAllOrderItemQueryResponse>>
    {
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public int DeskId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
