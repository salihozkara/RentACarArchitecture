using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context;

public class BaseDbContext:DbContext
{
    protected IConfiguration Configuration { get; set; }
    public BaseDbContext(DbContextOptions options,IConfiguration configuration):base(options)
    {
        Configuration = configuration;
    }

    public DbSet<Brand> Brands { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("RentACarConnectionString")));
        }
        
    }
}