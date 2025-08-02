using MediatR;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            request.TotalPrice = request.Items.Sum(item => item.TotalPrice);
            var ordrt = new RestaurantDashboardApi.Domain.Entities.Order(request.Items, request.TotalPrice, request.OrderStatusId, request.OrderDate,request.WaiterId);
            await _unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Order>().AddAsync(ordrt);
            await _unitOfWork.SaveAsync();
        }
    }
}
