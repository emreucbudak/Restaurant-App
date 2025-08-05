using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.RestaurantCase.Queries.GetAllCaseByEmailCommand
{
    public class GetAllCaseByEmailCommand : IRequestHandler<GetAllCaseByEmailRequest,GetAllCaseByEmailResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCaseByEmailCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllCaseByEmailResponse> Handle(GetAllCaseByEmailRequest request, CancellationToken cancellationToken)
        {
            var getCaseBy = await _unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.RestaurantCase>().GetByExpression(false, b => b.Email == request.Email).Include(b=> b.Restaurant).FirstOrDefaultAsync();
            return new GetAllCaseByEmailResponse()
            {
                RestaurantId = getCaseBy.RestaurantId
            };
        }
    }
}
