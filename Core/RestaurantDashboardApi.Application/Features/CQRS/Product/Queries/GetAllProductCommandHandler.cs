using MediatR;
using Microsoft.EntityFrameworkCore;

using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Product.Queries
{
    internal class GetAllProductCommandHandler : IRequestHandler<GetAllProductCommandRequest, IList<GetAllProductCommandResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllProductCommandResponse>> Handle(GetAllProductCommandRequest request, CancellationToken cancellationToken)
        {
            var finishedOrders = await _unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Product>()
                .GetAllAsync(include: x => x.Include(f => f.ProductCategory));
            var response = finishedOrders.Select(f => new GetAllProductCommandResponse
            {
                Id = f.Id,
                ProductName = f.ProductName,
                ProductDescription = f.ProductDescription,
                ProductPrice = f.ProductPrice,
                ProductCategoryName = f.ProductCategory.CategoryName
            }).ToList();
            return response;
        }
    }
}
