using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.RestaurantCase.Queries.GetAllCaseByEmailCommand
{
    public class GetAllCaseByEmailRequest : IRequest<GetAllCaseByEmailResponse> 
    {
        public string Email { get; set; }   
    }
}
