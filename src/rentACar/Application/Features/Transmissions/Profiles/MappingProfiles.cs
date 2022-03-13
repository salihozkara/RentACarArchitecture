using Application.Features.Transmissions.Commands.CreateTransmission;
using Application.Features.Transmissions.Commands.DeleteTransmission;
using Application.Features.Transmissions.Commands.UpdateTransmission;
using Application.Features.Transmissions.Dtos;
using Application.Features.Transmissions.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Transmissions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Create Command mapping
        CreateMap<Transmission, CreateTransmissionCommand>().ReverseMap();
        CreateMap<Transmission, CreatedTransmissionDto>().ReverseMap();
        // Update Command mapping
        CreateMap<Transmission, UpdateTransmissionCommand>().ReverseMap();
        CreateMap<Transmission, UpdatedTransmissionDto>().ReverseMap();
        // Delete Command mapping
        CreateMap<Transmission, DeleteTransmissionCommand>().ReverseMap();
        CreateMap<Transmission, DeletedTransmissionDto>().ReverseMap();
        // Select Query mapping
        CreateMap<Transmission, TransmissionListDto>().ReverseMap();
        CreateMap<Transmission, TransmissionDto>().ReverseMap();
        CreateMap<IPaginate<Transmission>, TransmissionListModel>().ReverseMap();
    }
}