using AutoMapper;
using RestaurantDashboardApi.Application.Features.CQRS.Auth.Command.Register;
using RestaurantDashboardApi.Application.Features.CQRS.Desk.Queries;
using RestaurantDashboardApi.Application.Features.CQRS.RestaurantCase.Queries.GetAllCaseCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Waiter.Queries;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Desk,GetAllDeskCommandResponse>().ReverseMap();
            CreateMap<RestaurantCase, GetAllRestaurantCaseCommandResponse>().ReverseMap();
            CreateMap<RegisterCommandRequest, User>()
    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<Waiter, GetAllWaiterCommandResponse>()
    .ForMember(dest => dest.WaiterWorkStatusName,
               opt => opt.MapFrom(src => src.WaiterWorkStatus.WaiterWorkStatusName));
        }
    }
}
