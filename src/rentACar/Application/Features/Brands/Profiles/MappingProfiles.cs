using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Commands.DeleteBrand;
using Application.Features.Brands.Commands.UpdateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Create Command mapping
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        // Update Command mapping
        CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
        // Delete Command mapping
        CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
        // Select Query mapping
        CreateMap<Brand, BrandListDto>().ReverseMap();
        CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
    }
}