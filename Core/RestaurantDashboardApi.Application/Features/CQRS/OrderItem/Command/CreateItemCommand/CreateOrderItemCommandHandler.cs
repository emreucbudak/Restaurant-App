using MediatR;
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
            
            var t = new RestaurantDashboardApi.Domain.Entities.OrderItem(request.OrderId,request.ProductId,
                request.Quantity,request.TotalPrice,request.DeskId); 
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.OrderItem>().AddAsync(t);
            await unitOfWork.SaveAsync();
        }
    }
}
