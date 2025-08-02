using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Desk.Command.UpdateCommand
{
    public class UpdateDeskCommandHandler : IRequestHandler<UpdateDeskCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDeskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateDeskCommandRequest request, CancellationToken cancellationToken)
        {
            var getDesk = await _unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Desk>().GetByExpression(true,b=> b.Id == request.Id).FirstOrDefaultAsync();
            getDesk.IsFull = request.IsFull;
            getDesk.DeskName = request.DeskName;
            await _unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Desk>().UpdateAsync(getDesk);
            await _unitOfWork.SaveAsync();
        }
    }
}
