﻿using Application.Features.Brands.Commands.CreateBrand;
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
        CreateMap<Brand, CreatedBrandDto>().ReverseMap();
        // Update Command mapping
        CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
        CreateMap<Brand, UpdatedBrandDto>().ReverseMap();
        // Delete Command mapping
        CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
        CreateMap<Brand, DeletedBrandDto>().ReverseMap();
        // Select Query mapping
        CreateMap<Brand, BrandListDto>().ReverseMap();
        CreateMap<Brand, BrandDto>().ReverseMap();
        CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
    }
}