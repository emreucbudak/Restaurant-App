using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Product.Command.DeleteCommand
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var getDesk = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Product>().GetByExpression(false, b => b.ProductName.Trim().ToLower() == request.ProductName.Trim().ToLower() ).FirstOrDefaultAsync();
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Product>().DeleteAsync(getDesk);
            await unitOfWork.SaveAsync();
        }
    }
}
