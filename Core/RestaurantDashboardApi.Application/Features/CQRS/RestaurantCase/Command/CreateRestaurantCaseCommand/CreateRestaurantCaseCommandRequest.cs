using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.RestaurantCase.Command.CreateRestaurantCaseCommand
{
    public class CreateRestaurantCaseCommandRequest : IRequest
    {
        public string CaseName { get; set; }
        public string CaseSurname { get; set; }
        public string CaseEmail { get; set; }
        public string CasePassword { get; set; }
    }
}
