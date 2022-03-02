using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public BaseDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Model> Models { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // if (!optionsBuilder.IsConfigured)
        // {
        //     base.OnConfiguring(
        //         optionsBuilder.UseSqlServer(Configuration.GetConnectionString("RentACarConnectionString")!));
        // }
    }
   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Brand>(b =>
            {
                b.ToTable("Brand").HasKey(x => x.Id);
                b.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                b.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
                b.HasMany(x => x.Models).WithOne(x => x.Brand).HasForeignKey(x => x.BrandId);
            }
        );
        modelBuilder.Entity<Model>(m =>
            {
                m.ToTable("Model").HasKey(x => x.Id);
                m.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                m.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
                m.Property(x => x.BrandId).HasColumnName("BrandId").IsRequired();
            }
        );
    }
}