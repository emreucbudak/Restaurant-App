using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.OrderItem.Command.CreateItemCommand
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateOrderItemCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateOrderItemCommandRequest request, CancellationToken cancellationToken)
        {
            // 1. Ürünü getir
            var product = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Product>()
                .GetByExpression(true, x => x.Id == request.ProductId)
                .FirstOrDefaultAsync(cancellationToken);

            if (product == null)
                throw new Exception("Product not found.");

            // 2. Siparişi getir (OrderId bilgisi request'te olmalı, yoksa önce sipariş oluşturman gerek)
            var order = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Order>()
                .GetByExpression(true, o => o.Id == request.OrderId) // request.OrderId eklemelisin
                .FirstOrDefaultAsync(cancellationToken);

            if (order == null)
                throw new Exception("Order not found.");

            // 3. Sipariş kaleminin toplam fiyatını hesapla (adet * birim fiyat)
            int totalPrice = product.ProductPrice * request.Quantity;

            // 4. OrderItem nesnesini oluştur
            var orderItem = new RestaurantDashboardApi.Domain.Entities.OrderItem(order.Id, product.Id, request.Quantity, totalPrice);

            // 5. Order toplam fiyatını güncelle
            order.TotalPrice += totalPrice;

            // 6. Veritabanına ekle ve güncelle
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.OrderItem>().AddAsync(orderItem);
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Order>().UpdateAsync(order);

            // 7. Kaydet
            await unitOfWork.SaveAsync();


        }

    }
}
