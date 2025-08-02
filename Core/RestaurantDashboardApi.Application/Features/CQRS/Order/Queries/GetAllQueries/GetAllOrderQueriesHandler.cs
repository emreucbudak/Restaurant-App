using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetAllQueries.DTOS;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetAllQueries
{
    public class GetAllOrderQueriesHandler : IRequestHandler<GetAllOrderQueriesRequest, IList<GetAllOrderQueriesResponse>>
    {
        private readonly IUnitOfWork unitOfWork;


        public GetAllOrderQueriesHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllOrderQueriesResponse>> Handle(GetAllOrderQueriesRequest request, CancellationToken cancellationToken)
        {
            var finishedOrders = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Order>()
                .GetAllAsync(include: x => x
                    .Include(f => f.OrderStatus)
                    .Include(f => f.Items)
                        .ThenInclude(i => i.Product).Include(x => x.Waiter));

            var response = finishedOrders.Select(f => new GetAllOrderQueriesResponse
            {
                Id = f.Id,
                OrderDate = f.OrderDate,
                OrderStatusName = f.OrderStatus.StatusName,
                UpdatedAt = f.UpdatedAt,
                TotalPrice = f.TotalPrice,
                Products = f.Items.Select(b => new ProductInfoDTO
                {
                    ProductName = b.Product.ProductName,
                    ProductPrice = b.Product.ProductPrice
                }).ToList(),
                WaiterId = f.WaiterId,
                WaiterName = f.Waiter.Name+ " " + f.Waiter.Surname
                
            }).ToList();

            return response;
        }

        }

    }

