using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Product.Command.DeleteCommand
{
    public class DeleteProductCommandRequest : IRequest
    {
        public int ProductId { get; set; }
    }
}
