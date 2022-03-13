using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add the database context
        services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("rentACarConnectionString")!));
        
        // Repositories
        // Brand
        services.AddScoped<IBrandRepository, BrandRepository>();
        // Car
        services.AddScoped<ICarRepository, CarRepository>();
        // Color
        services.AddScoped<IColorRepository, ColorRepository>();
        // Fuel
        services.AddScoped<IFuelRepository, FuelRepository>();
        // Model
        services.AddScoped<IModelRepository, ModelRepository>();
        // Transmission
        services.AddScoped<ITransmissionRepository, TransmissionRepository>();
        // User
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}