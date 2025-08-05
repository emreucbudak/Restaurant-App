using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Command.UpdateCommand.UpdateStatusOrderRequest
{
    public class UpdateStatusOrderRequestHandler : IRequestHandler<UpdateStatusRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateStatusOrderRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateStatusRequest request, CancellationToken cancellationToken)
        {
            var ds = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Order>()
                .GetByExpression(trackChanges: true, expression: x => x.Id == request.OrderId).FirstOrDefaultAsync();
            ds.OrderStatusId = request.NewStatus;
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Order>()
    .UpdateAsync(ds);
            await unitOfWork.SaveAsync();
        }
    }
}
