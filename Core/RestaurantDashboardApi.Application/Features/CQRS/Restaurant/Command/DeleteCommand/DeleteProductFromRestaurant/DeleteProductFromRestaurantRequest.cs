using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Command.DeleteCommand.DeleteProductFromRestaurant
{
    public class DeleteProductFromRestaurantRequest : IRequest
    {
        public int RestaurantId { get; set; }
        public string ProductName { get; set; }
    }
}
