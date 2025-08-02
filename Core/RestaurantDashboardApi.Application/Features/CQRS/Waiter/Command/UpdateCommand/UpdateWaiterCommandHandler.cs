using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Waiter.Command.UpdateCommand
{
    public class UpdateWaiterCommandHandler : IRequestHandler<UpdateWaiterCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateWaiterCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateWaiterCommandRequest request, CancellationToken cancellationToken)
        {
            var get = await _unitOfWork.GetReadRepository<RestaurantDashboardApi.Domain.Entities.Waiter>().GetByExpression(true, b => b.Id == request.Id).FirstOrDefaultAsync();
            get.Name = request.Name;
            get.Surname = request.Surname;
            get.Email = request.Email;
            get.Password = request.Password;
            await _unitOfWork.GetWriteRepository < RestaurantDashboardApi.Domain.Entities.Waiter >().UpdateAsync(get);
                            await _unitOfWork.SaveAsync();
        }
    }
}
