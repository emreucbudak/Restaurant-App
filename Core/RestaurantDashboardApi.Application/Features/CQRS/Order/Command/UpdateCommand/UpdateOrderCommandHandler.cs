using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Command.UpdateCommand
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest>
    {
        private readonly IUnitOfWork  unitOfWork;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var gt = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Order>().GetByExpression(false, b => b.Id == request.OrderId).FirstOrDefaultAsync();
            gt.TotalPrice = request.TotalPrice;
            gt.UpdatedAt = DateTime.Now - gt.OrderDate;
            gt.OrderStatusId = request.OrderStatusId;
            gt.Items = request.Items;
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Order>().UpdateAsync(gt);
            await unitOfWork.SaveAsync();
        }
    }
}
