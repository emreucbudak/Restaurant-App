using AutoMapper;
using MediatR;

using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Desk.Queries
{
    public class GetAllDeskCommandHandler : IRequestHandler<GetAllDeskCommandRequest, IList<GetAllDeskCommandResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mp;
        public GetAllDeskCommandHandler(IUnitOfWork unitOfWork , IMapper _mp)
        {
            this.unitOfWork = unitOfWork;
            mp = _mp;
        }

        public async Task<IList<GetAllDeskCommandResponse>> Handle(GetAllDeskCommandRequest request, CancellationToken cancellationToken)
        {
            var getAll =  await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Desk>().GetAllAsync(predicate: b => b.RestaurantId == request.RestaurantId);
            var rtn = mp.Map<IList<GetAllDeskCommandResponse>>(getAll);
            return rtn;
        }
    }
}
