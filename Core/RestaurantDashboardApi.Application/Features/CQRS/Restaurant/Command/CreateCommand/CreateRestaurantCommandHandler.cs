using MediatR;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Command.CreateCommand
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateRestaurantCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateRestaurantCommandRequest request, CancellationToken cancellationToken)
        {
            var restaurant = new RestaurantDashboardApi.Domain.Entities.Restaurant(request.RestaurantName,request.RestaurantCaseId);
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.Restaurant>().AddAsync(restaurant);
            await unitOfWork.SaveAsync();
        }
    }
}
