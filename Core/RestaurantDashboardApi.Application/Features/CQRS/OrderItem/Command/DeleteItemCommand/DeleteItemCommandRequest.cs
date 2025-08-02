using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.OrderItem.Command.DeleteItemCommand
{
    public class DeleteItemCommandRequest : IRequest
    {
        public int Id   { get; set; }
    }
}
