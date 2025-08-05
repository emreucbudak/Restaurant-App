using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetAllQueries.GetUnConfirmedOrdersByWaiter
{
    public class GetWaiterUnConfirmedOrdersRequestHandler : IRequestHandler<GetWaiterUnConfirmedOrdersRequest, IList<GetWaiterUnConfirmedOrdersResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetWaiterUnConfirmedOrdersRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetWaiterUnConfirmedOrdersResponse>> Handle(GetWaiterUnConfirmedOrdersRequest request, CancellationToken cancellationToken)
        {

            var gets = await unitOfWork
                .GetReadRepository<RestaurantDashboardApi.Domain.Entities.Order>()
                .GetAllAsync(
                    predicate: x => x.WaiterId == request.WaiterId && x.Desk.RestaurantId == request.RestaurantId,
                    include: query => query
                        .Include(x => x.Desk).Include(x=> x.OrderStatus)
                        .Include(x => x.OrderItems).ThenInclude(x=> x.Product)
                );



            var ds = gets.Select(x => new GetWaiterUnConfirmedOrdersResponse
            {
                OrderId = x.Id,
                TotalPrice = x.TotalPrice,
                DeskName = x.Desk.DeskName,
                OrderNote = x.OrderNote,
                OrderItems = x.OrderItems.Select(y => new ProductInfos()
                {
                    Price = y.Product.ProductPrice,
                    ProductName = y.Product.ProductName,
                    Quantity = y.Quantity
                }).ToList(),
                OrderStatus = x.OrderStatus.StatusName
            }).ToList();

            return ds;
        }
    }
}
