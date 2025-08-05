using MediatR;
using Microsoft.EntityFrameworkCore;

using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.OrderItem.Command.Queries
{
    public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemQueryRequest, IList<GetAllOrderItemQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllOrderItemsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllOrderItemQueryResponse>> Handle(GetAllOrderItemQueryRequest request, CancellationToken cancellationToken)
        {
            var finishedOrders = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.OrderItem>()
                .GetAllAsync(include: x => x.Include(f => f.Order)
                                            .Include(f => f.Product));

            var response = finishedOrders.Select(f => new GetAllOrderItemQueryResponse
            {
                Id = f.Id,
                ProductName  = f.Product.ProductName,
                Quantity = f.Quantity,
                TotalPrice  = f.TotalPrice,

            }).ToList();

            return response;
        }
    }
}
