using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Command.CreateCommand
{
    public class CreateRestaurantCommandRequest : IRequest
    {
        public string RestaurantName { get; set; }
        public int RestaurantCaseId { get; set; }
    }
}
