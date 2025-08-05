using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Command.DeleteCommand.DeleteProductFromRestaurant
{
    public class DeleteProductFromRestaurantRequestHandler : IRequestHandler<DeleteProductFromRestaurantRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteProductFromRestaurantRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProductFromRestaurantRequest request, CancellationToken cancellationToken)
        {
            // Restaurant'ı ürünleriyle beraber çekiyoruz
            var restaurant = await unitOfWork
                .GetReadRepository<RestaurantDashboardApi.Domain.Entities.Restaurant>()
                .GetByExpression(false, b => b.Id == request.RestaurantId)
                .Include(b => b.Products)
                .FirstOrDefaultAsync();

            if (restaurant == null)
            {
                throw new Exception("Restaurant bulunamadı.");
            }

            // İlgili ürünü bul
            var product = restaurant.Products
                .FirstOrDefault(p => p.ProductName.Trim().ToLower() == request.ProductName.Trim().ToLower());

            if (product == null)
            {
                throw new Exception("Ürün bulunamadı.");
            }

            // Ürünü sil
            await unitOfWork
                .GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Product>()
                .DeleteAsync(product);

            await unitOfWork.SaveAsync();
        }

    }
}
