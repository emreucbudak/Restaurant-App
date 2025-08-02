using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Command.DeleteCommand
{
    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteRestaurantCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteRestaurantCommandRequest request, CancellationToken cancellationToken)
        {
            var getRestaurantCommand = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Restaurant>().GetByExpression(false,b => b.Id == request.Id).FirstOrDefaultAsync();
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Restaurant>().DeleteAsync(getRestaurantCommand);
            await unitOfWork.SaveAsync();
        }
    }
}
