using MediatR;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Product.Command.CreateCommand
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var ts = new RestaurantDashboardApi.Domain.Entities.Product(request.ProductName, request.ProductDescription, request.ProductPrice, request.ProductCategoryId);
            await _unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Product>().AddAsync(ts);
            await _unitOfWork.SaveAsync();
                
        }
    }
}
