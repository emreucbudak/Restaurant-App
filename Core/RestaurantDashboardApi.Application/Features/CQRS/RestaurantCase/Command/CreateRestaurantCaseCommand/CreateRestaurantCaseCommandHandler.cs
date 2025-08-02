using MediatR;
using RestaurantDashboardApi.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.RestaurantCase.Command.CreateRestaurantCaseCommand
{
    public class CreateRestaurantCaseCommandHandler : IRequestHandler<CreateRestaurantCaseCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateRestaurantCaseCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateRestaurantCaseCommandRequest request, CancellationToken cancellationToken)
        {
            request.CasePassword = BCrypt.Net.BCrypt.EnhancedHashPassword(request.CasePassword);
            var restaurantCase = new RestaurantDashboardApi.Domain.Entities.RestaurantCase(request.CaseName, request.CaseSurname, request.CaseEmail, request.CasePassword);
            await unitOfWork.GetWriteRepository<RestaurantDashboardApi.Domain.Entities.RestaurantCase>().AddAsync(restaurantCase);
            await unitOfWork.SaveAsync();
        }
    }
}
