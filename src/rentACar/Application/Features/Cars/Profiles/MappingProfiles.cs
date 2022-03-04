using Application.Features.Cars.Commands.CreateCar;
using Application.Features.Cars.Dtos;
using Application.Features.Cars.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Cars.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Create Command Mapping
        CreateMap<Car, CreateCarCommand>().ReverseMap();
        // Get List Query Mapping
        CreateMap<Car, CarListDto>().ForMember(c => c.ColorName, opt => opt.MapFrom(c => c.Color.Name))
            .ForMember(c => c.ModelName, opt => opt.MapFrom(c => c.Model.Name))
            .ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Model.Brand.Name));
        CreateMap<IPaginate<Car>, CarListModel>().ReverseMap();
    }
}