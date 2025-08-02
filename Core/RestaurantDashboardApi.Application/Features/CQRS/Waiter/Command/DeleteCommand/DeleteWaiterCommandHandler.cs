using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Waiter.Command.DeleteCommand
{
    public class DeleteWaiterCommandHandler : IRequestHandler<DeleteWaiterCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteWaiterCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteWaiterCommandRequest request, CancellationToken cancellationToken)
        {
            var get = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Waiter>().GetByExpression(false,b => b.Id == request.Id).FirstOrDefaultAsync();
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Waiter>().DeleteAsync(get);
            await unitOfWork.SaveAsync();

        }
    }
}
