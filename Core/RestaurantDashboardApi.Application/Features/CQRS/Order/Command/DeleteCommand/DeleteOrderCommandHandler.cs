using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Command.DeleteCommand
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var gt =  await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Order>().GetByExpression(false,b => b.Id == request.Id).FirstOrDefaultAsync();
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Order>().DeleteAsync(gt);
            await unitOfWork.SaveAsync();

        }
    }
}
