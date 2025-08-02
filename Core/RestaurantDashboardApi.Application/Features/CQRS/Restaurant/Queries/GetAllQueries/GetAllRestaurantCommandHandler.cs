using AutoMapper;
using MediatR;

using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Queries.GetAllQueries
{
    public class GetAllRestaurantCommandHandler : IRequestHandler<GetAllRestaurantCommandRequest, IList<GetAllRestaurantCommandResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mp;

        public GetAllRestaurantCommandHandler(IUnitOfWork unitOfWork, IMapper mp)
        {
            this.unitOfWork = unitOfWork;
            this.mp = mp;
        }

        public async Task<IList<GetAllRestaurantCommandResponse>> Handle(GetAllRestaurantCommandRequest request, CancellationToken cancellationToken)
        {
            var td = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Restaurant>().GetAllAsync();
            var ts =  mp.Map<IList<GetAllRestaurantCommandResponse>>(td);
            return ts;
        }
    }
}
