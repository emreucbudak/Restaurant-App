using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Command.CreateCommand
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderItemCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateOrderItemCommandRequest request, CancellationToken cancellationToken)
        {
            // Toplam fiyatı Items üzerinden yeniden hesapla
            request.TotalPrice = request.Items.Sum(item => item.TotalPrice);

            // Order nesnesini oluştururken Items koleksiyonunu OrderItems olarak geçiriyoruz
            var orderItems = request.Items.Select(dto => new RestaurantDashboardApi.Domain.Entities.OrderItem
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                TotalPrice = dto.TotalPrice,
                // OrderId burada yok çünkü Order yeni oluşturulacak, EF Core bunu otomatik bağlar.
            }).ToList();
            var order = new RestaurantDashboardApi.Domain.Entities.Order(
                items: orderItems,
                totalPrice: request.TotalPrice,
                orderStatusId: request.OrderStatusId,
                orderDate: request.OrderDate,
                waiterId: request.WaiterId,
                deskId: request.DeskId
                
            );

            // Eğer istersen diğer propertyleri de set edebilirsin (DeskId, OrderNote vb)
            // order.DeskId = request.DeskId;
            // order.OrderNote = request.OrderNote;

            await _unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Order>().AddAsync(order);
            var desk = await _unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Desk>().GetByExpression(trackChanges:true,expression: x=> x.Id == request.DeskId).FirstOrDefaultAsync();

            if (desk != null)
            {
                // Örneğin, sipariş gizli değilse masa dolu sayılır
                desk.IsFull = true;

                await _unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Desk>().UpdateAsync(desk);
                await _unitOfWork.SaveAsync();
            }
            await _unitOfWork.SaveAsync();
        }
    }
}
