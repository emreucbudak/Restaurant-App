using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.RestaurantCase.Command.DeleteRestaurantCaseCommand
{
    public class DeleteRestaurantCaseCommandHandler : IRequestHandler<DeleteRestaurantCaseCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteRestaurantCaseCommandHandler(IUnitOfWork unitOfWork
            )
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteRestaurantCaseCommandRequest request, CancellationToken cancellationToken)
        {
            var getRestaurantCase =  await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.RestaurantCase>().GetByExpression(false, b => b.Id == request.Id).FirstOrDefaultAsync();
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.RestaurantCase>().DeleteAsync(getRestaurantCase);
            await unitOfWork.SaveAsync();
        }
    }
}
