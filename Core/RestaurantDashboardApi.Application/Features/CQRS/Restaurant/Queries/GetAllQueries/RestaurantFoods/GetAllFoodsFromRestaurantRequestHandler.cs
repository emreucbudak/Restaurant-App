using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Queries.GetAllQueries.RestaurantFoods
{
    public class GetAllFoodsFromRestaurantRequestHandler : IRequestHandler<GetAllFoodsFromRestaurantRequest, IList<GetAllFoodsFromRestaurantResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllFoodsFromRestaurantRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllFoodsFromRestaurantResponse>> Handle(GetAllFoodsFromRestaurantRequest request, CancellationToken cancellationToken)
        {
            var ds = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Restaurant>().GetByExpression(false, expression: b => b.Id == request.Id).Include(b=> b.Products).ThenInclude(b=> b.ProductCategory).ToListAsync();
            return ds.Select(b => new GetAllFoodsFromRestaurantResponse()
            {
                Categories = b.Products
                              .Where(p => p.ProductCategory != null)
                              .Select(p => p.ProductCategory.CategoryName)
                              .Distinct()
                              .ToList(),
                Products = b.Products.ToList(),
            }).ToList();


        }
    }
}
