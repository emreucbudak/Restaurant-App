using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Command.DeleteCommand.DeleteWaiterOrder
{

    public class DeleteWaiterOrderRequestHandler : IRequestHandler<DeleteWaiterOrderRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteWaiterOrderRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteWaiterOrderRequest request, CancellationToken cancellationToken)
        {
            var ds = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Order>()
                .GetByExpression(trackChanges:true,expression:x=> x.Id == request.OrderId).FirstOrDefaultAsync();
            ds.OrderStatusId = 6;
            var ts = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Desk>()
                .GetByExpression(trackChanges: true, expression: x => x.Id == ds.DeskId).FirstOrDefaultAsync();
            ts.IsFull = false;
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Desk>()
                .UpdateAsync(ts);   

            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Order>()
                .UpdateAsync(ds);
            await unitOfWork.SaveAsync();
        }
    }
}
