using Application.Features.Models.Commands.CreateModel;
using Application.Features.Models.Commands.DeleteModel;
using Application.Features.Models.Commands.UpdateModel;
using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Create Command mapping
        CreateMap<Model, CreateModelCommand>().ReverseMap();
        CreateMap<Model, CreatedModelDto>().ReverseMap();
        // Update Command mapping
        CreateMap<Model, UpdateModelCommand>().ReverseMap();
        CreateMap<Model, UpdatedModelDto>().ReverseMap();
        // Delete Command mapping
        CreateMap<Model, DeleteModelCommand>().ReverseMap();
        CreateMap<Model, DeletedModelDto>().ReverseMap();
        // Select Query mapping
        CreateMap<Model, ModelListDto>().ReverseMap();
        CreateMap<Model, ModelDto>().ReverseMap();
        CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();
    }
}