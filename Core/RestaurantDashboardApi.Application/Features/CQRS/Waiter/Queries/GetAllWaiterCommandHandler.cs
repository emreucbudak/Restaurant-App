using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Waiter.Queries
{
    public class GetAllWaiterCommandHandler : IRequestHandler<GetAllWaiterCommandRequest, IList<GetAllWaiterCommandResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;

        public GetAllWaiterCommandHandler(IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
        }

        public async Task<IList<GetAllWaiterCommandResponse>> Handle(GetAllWaiterCommandRequest request, CancellationToken cancellationToken)
        {
            var tr = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Waiter>().GetByExpression(false , b=> b.RestaurantId == request.RestaurantId).ToListAsync();

            
            var ds = autoMapper.Map<IList<GetAllWaiterCommandResponse>>(tr);
            return ds;
        }
    }
}
