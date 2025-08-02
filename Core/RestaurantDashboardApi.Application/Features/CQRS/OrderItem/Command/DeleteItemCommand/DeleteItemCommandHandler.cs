using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.OrderItem.Command.DeleteItemCommand
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteItemCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteItemCommandRequest request, CancellationToken cancellationToken)
        {
            var getDesk = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.OrderItem>().GetByExpression(true, b => b.Id == request.Id).FirstOrDefaultAsync();
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.OrderItem>().DeleteAsync(getDesk);
            await unitOfWork.SaveAsync();
        }
    }
}
