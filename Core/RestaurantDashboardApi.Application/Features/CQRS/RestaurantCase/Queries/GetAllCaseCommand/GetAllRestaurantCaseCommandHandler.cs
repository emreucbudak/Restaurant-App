using AutoMapper;
using MediatR;

using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.RestaurantCase.Queries.GetAllCaseCommand
{
    public class GetAllRestaurantCaseCommandHandler : IRequestHandler<GetAllRestaurantCaseCommandRequest, IList<GetAllRestaurantCaseCommandResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;

        public GetAllRestaurantCaseCommandHandler(IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
        }

        public async Task<IList<GetAllRestaurantCaseCommandResponse>> Handle(GetAllRestaurantCaseCommandRequest request, CancellationToken cancellationToken)
        {
            var getAllRestaurantCase = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.RestaurantCase>().GetAllAsync();

            var getAllRestaurantCases =  autoMapper.Map<List<GetAllRestaurantCaseCommandResponse>>(getAllRestaurantCase);
            return getAllRestaurantCases;
        }
    }
}
