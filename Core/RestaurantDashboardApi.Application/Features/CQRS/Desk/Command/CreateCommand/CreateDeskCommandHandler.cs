using MediatR;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Desk.Command.CreateCommand
{
    public class CreateDeskCommandHandler : IRequestHandler<CreateDeskCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateDeskCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateDeskCommandRequest request, CancellationToken cancellationToken)
        {
            var desk = new RestaurantDashboardApi.Domain.Entities.Desk(request.DeskName, request.RestaurantId, request.IsFull);
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Desk>().AddAsync(desk);
            await unitOfWork.SaveAsync();
        }
    }
}
