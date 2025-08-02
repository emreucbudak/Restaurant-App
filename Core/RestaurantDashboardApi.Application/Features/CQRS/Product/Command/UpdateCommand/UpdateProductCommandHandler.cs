using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Product.Command.UpdateCommand
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var getDesk = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Product>().GetByExpression(true, b => b.Id == request.ProductId).FirstOrDefaultAsync();
            getDesk.ProductDescription = request.ProductDescription;
            getDesk.ProductName = request.ProductName;
            getDesk.ProductPrice = request.ProductPrice;
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Product>().UpdateAsync(getDesk);
            await unitOfWork.SaveAsync();
        }
    }
}
