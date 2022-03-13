using Application.Features.Cars.Commands.CreateCar;
using Application.Features.Cars.Commands.DeleteCar;
using Application.Features.Cars.Commands.UpdateCar;
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
        // Car to CarDto
        CreateMap<Car, CarDto>();
        // Create Command Mapping
        CreateMap<Car, CreateCarCommand>().ReverseMap();
        CreateMap<Car, CreatedCarDto>().ReverseMap();
        // Update Command Mapping
        CreateMap<Car, UpdateCarCommand>().ReverseMap();
        CreateMap<Car, UpdatedCarDto>().ReverseMap();
        // Delete Command Mapping
        CreateMap<Car, DeleteCarCommand>().ReverseMap();
        CreateMap<Car, DeletedCarDto>().ReverseMap();
        // Get List Query Mapping
        CreateMap<Car, CarListDto>().ForMember(c => c.ColorName, opt => opt.MapFrom(c => c.Color.Name))
            .ForMember(c => c.ModelName, opt => opt.MapFrom(c => c.Model.Name))
            .ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Model.Brand.Name));
        CreateMap<IPaginate<Car>, CarListModel>().ReverseMap();
    }
}