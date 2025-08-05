using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Command.UpdateCommand.UpdateOrderStaus
{
    public class UpdateOrderStatusRequestHandler : IRequestHandler<UpdateOrderStatusRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateOrderStatusRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateOrderStatusRequest request, CancellationToken cancellationToken)
        {
            var ds = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Order>()
                .GetByExpression(trackChanges: true, expression: x => x.Id == request.OrderId).Include(x=> x.OrderStatus).FirstOrDefaultAsync();
            ds.OrderStatusId = 2;
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Order>()
                .UpdateAsync(ds);
            await unitOfWork.SaveAsync();

        }
    }
}
