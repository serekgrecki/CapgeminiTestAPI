using AutoMapper;
using static AutoMapper.Mapper;
using Backend.Models;
using Backend.ViewModels;
using Ninject;

namespace Backend.Infrastructure.Automapper
{
    public class DefaultProfile : Profile
    {
        private readonly StandardKernel _kernel;

        public DefaultProfile()
        {
            _kernel = new StandardKernel();

            CreateMap<CustomerModel, CustomerVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Address1, opt => opt.MapFrom(src => src.Address1))
                .ForMember(dest => dest.Address2, opt => opt.MapFrom(src => src.Address2))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.ZIP, opt => opt.MapFrom(src => src.ZIP))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ReverseMap();
        }
    }
}