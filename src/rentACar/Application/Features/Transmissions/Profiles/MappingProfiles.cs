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
        // Update Command mapping
        CreateMap<Transmission, UpdateTransmissionCommand>().ReverseMap();
        // Delete Command mapping
        CreateMap<Transmission, DeleteTransmissionCommand>().ReverseMap();
        // Select Query mapping
        CreateMap<Transmission, TransmissionListDto>().ReverseMap();
        CreateMap<IPaginate<Transmission>, TransmissionListModel>().ReverseMap();
    }
}