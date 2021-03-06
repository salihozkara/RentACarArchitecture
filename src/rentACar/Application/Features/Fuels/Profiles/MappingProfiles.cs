using Application.Features.Fuels.Commands.CreateFuel;
using Application.Features.Fuels.Commands.DeleteFuel;
using Application.Features.Fuels.Commands.UpdateFuel;
using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Fuels.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Create Command mapping
        CreateMap<Fuel, CreateFuelCommand>().ReverseMap();
        CreateMap<Fuel, CreatedFuelDto>().ReverseMap();
        // Update Command mapping
        CreateMap<Fuel, UpdateFuelCommand>().ReverseMap();
        CreateMap<Fuel, UpdatedFuelDto>().ReverseMap();
        // Delete Command mapping
        CreateMap<Fuel, DeleteFuelCommand>().ReverseMap();
        CreateMap<Fuel, DeletedFuelDto>().ReverseMap();
        // Select Query mapping
        CreateMap<Fuel, FuelListDto>().ReverseMap();
        CreateMap<Fuel, FuelDto>().ReverseMap();
        CreateMap<IPaginate<Fuel>, FuelListModel>().ReverseMap();
    }
}