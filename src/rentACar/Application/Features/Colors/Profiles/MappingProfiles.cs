using Application.Features.Colors.Commands.CreateColor;
using Application.Features.Colors.Commands.DeleteColor;
using Application.Features.Colors.Commands.UpdateColor;
using Application.Features.Colors.Dtos;
using Application.Features.Colors.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Colors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Create Command mapping
        CreateMap<Color, CreateColorCommand>().ReverseMap();
        // Update Command mapping
        CreateMap<Color, UpdateColorCommand>().ReverseMap();
        // Delete Command mapping
        CreateMap<Color, DeleteColorCommand>().ReverseMap();
        // Select Query mapping
        CreateMap<Color, ColorListDto>().ReverseMap();
        CreateMap<IPaginate<Color>, ColorListModel>().ReverseMap();
    }
}