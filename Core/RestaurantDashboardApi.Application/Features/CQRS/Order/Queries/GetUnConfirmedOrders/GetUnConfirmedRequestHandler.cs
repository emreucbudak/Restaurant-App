using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetUnConfirmedOrders
{
    public class GetUnConfirmedRequestHandler : IRequestHandler<GetUnConfirmedOrdersRequest, IList<GetUnConfirmedOrderResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetUnConfirmedRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async  Task<IList<GetUnConfirmedOrderResponse>> Handle(GetUnConfirmedOrdersRequest request, CancellationToken cancellationToken)
        {
            var ds = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Order>()
                .GetByExpression(false, x => x.Desk.RestaurantId == request.RestaurantId&& x.OrderStatusId == 1).Include(x=> x.OrderStatus).Include(x => x.OrderItems).ThenInclude(x => x.Product)
                .Select(x => new GetUnConfirmedOrderResponse
                {
                    OrderId = x.Id,
                    TotalPrice = x.TotalPrice,
                    DeskName = x.Desk.DeskName,
                    OrderNote = x.OrderNote,
                    OrderItems = x.OrderItems.Select(y => new ProductInfo
                    {
                        ProductName = y.Product.ProductName,
                        Price = y.TotalPrice,
                        Quentity = y.Quantity
                    }).ToList(),
                    WaiterName = x.Waiter.Name,
                    Status = x.OrderStatus.StatusName
                }).ToListAsync();
            return ds;
        }
    }
}
