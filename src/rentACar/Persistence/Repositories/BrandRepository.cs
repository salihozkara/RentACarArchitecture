using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class BrandRepository:EfRepositoryBase<Brand,BaseDbContext>,IBrandRepository
{
    public BrandRepository(BaseDbContext context) : base(context)
    {
    }
}
