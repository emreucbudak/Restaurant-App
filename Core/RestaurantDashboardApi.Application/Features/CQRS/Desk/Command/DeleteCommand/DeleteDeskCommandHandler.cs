using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Desk.Command.DeleteCommand
{
    public class DeleteDeskCommandHandler : IRequestHandler<DeleteDeskCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteDeskCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteDeskCommandRequest request, CancellationToken cancellationToken)
        {
            var getDesk = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Desk>().GetByExpression(false,b => b.Id == request.Id).FirstOrDefaultAsync();
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Desk>().DeleteAsync(getDesk);
            await unitOfWork.SaveAsync();
        }
    }
}
