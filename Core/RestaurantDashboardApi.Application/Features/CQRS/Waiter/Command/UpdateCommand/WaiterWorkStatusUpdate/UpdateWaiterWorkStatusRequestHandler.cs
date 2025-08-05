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

namespace RestaurantDashboardApi.Application.Features.CQRS.Waiter.Command.UpdateCommand.WaiterWorkStatusUpdate
{
    public class UpdateWaiterWorkStatusRequestHandler : IRequestHandler<UpdateWaiterWorkStatusRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateWaiterWorkStatusRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateWaiterWorkStatusRequest request, CancellationToken cancellationToken)
        {
            var ds = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Waiter>().GetByExpression(expression:b=> b.Email == request.Email,trackChanges:true).FirstOrDefaultAsync();
            ds.WaiterWorkStatusId = ds.WaiterWorkStatusId switch
            {
                1 => ds.WaiterWorkStatusId = 3,
                3 => ds.WaiterWorkStatusId = 1,
                _ => throw new Exception("yanlis deger ")
            };
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Waiter>().UpdateAsync(ds);
            await unitOfWork.SaveAsync();
        }
    }
}
