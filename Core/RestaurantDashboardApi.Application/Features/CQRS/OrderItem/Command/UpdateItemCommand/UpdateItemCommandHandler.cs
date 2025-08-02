using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.OrderItem.Command.UpdateItemCommand
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateItemCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateItemCommandRequest request, CancellationToken cancellationToken)
        {
            var getDesk = await unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.OrderItem>().GetByExpression(true, b => b.Id == request.Id).FirstOrDefaultAsync();
            getDesk.TotalPrice = request.TotalPrice;
            getDesk.Quantity = request.Quantity;    
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.OrderItem>().UpdateAsync(getDesk);
            await unitOfWork.SaveAsync();
        }
    }
}
