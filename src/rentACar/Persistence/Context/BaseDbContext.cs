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
    // DbSet<TEntity> property will be used to query and save instances of TEntity
    // Brand
    public DbSet<Brand> Brands { get; set; }
    // Car
    public DbSet<Car> Cars { get; set; }
    // Color
    public DbSet<Color> Colors { get; set; }
    // Fuel
    public DbSet<Fuel> Fuels { get; set; }
    // Model
    public DbSet<Model> Models { get; set; }
    // Transmission
    public DbSet<Transmission> Transmissions { get; set; }
    
    // ModelBuilder is used to configure the model that was just created
   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // Brand entity configuration
        modelBuilder.Entity<Brand>(b =>
            {
                // Primary Key
                b.ToTable("Brand").HasKey(x => x.Id);
                // Properties
                b.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                b.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
                // Relationships
                b.HasMany(x => x.Models).WithOne(x => x.Brand).HasForeignKey(x => x.BrandId);
            }
        );
        // Car entity configuration
        modelBuilder.Entity<Car>(c =>
        {
            // Primary Key
            c.ToTable("Car").HasKey(x => x.Id);
            // Properties
            c.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            c.Property(x=>x.ModelId).HasColumnName("ModelId").IsRequired();
            c.Property(x => x.ColorId).HasColumnName("ColorId").IsRequired();
            c.Property(x=>x.ModelYear).HasColumnName("ModelYear").IsRequired();
            c.Property(x=>x.Plate).HasColumnName("Plate").HasMaxLength(10).IsRequired();
            c.Property(x=>x.CarState).HasColumnName("CarState").IsRequired();
            // Relationships
            c.HasOne(x => x.Model).WithMany(x => x.Cars).HasForeignKey(x => x.ModelId);
            c.HasOne(x => x.Color).WithMany(x => x.Cars).HasForeignKey(x => x.ColorId);
        });
        // Color entity configuration
        modelBuilder.Entity<Color>(c =>
        {
            // Primary Key
            c.ToTable("Color").HasKey(x => x.Id);
            // Properties
            c.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            c.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            // Relationships
            c.HasMany(x => x.Cars).WithOne(x => x.Color).HasForeignKey(x => x.ColorId);
        });
        // Fuel entity configuration
        modelBuilder.Entity<Fuel>(f =>
        {
            // Primary Key
            f.ToTable("Fuel").HasKey(x => x.Id);
            // Properties
            f.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            f.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            // Relationships
            f.HasMany(x=>x.Models).WithOne(x=>x.Fuel).HasForeignKey(x=>x.FuelId);
        });
        // Model entity configuration
        modelBuilder.Entity<Model>(m =>
        {
            // Primary Key
            m.ToTable("Model").HasKey(x => x.Id);
            // Properties
            m.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            m.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            m.Property(x => x.BrandId).HasColumnName("BrandId").IsRequired();
            // Relationships
            m.HasOne(x => x.Brand).WithMany(x => x.Models).HasForeignKey(x => x.BrandId);
            
            m.HasMany(x => x.Cars).WithOne(x => x.Model).HasForeignKey(x => x.ModelId);
        });
        // Transmission entity configuration
        modelBuilder.Entity<Transmission>(t =>
        {
            // Primary Key
            t.ToTable("Transmission").HasKey(x => x.Id);
            // Properties
            t.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            t.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            // Relationships
            t.HasMany(x => x.Models).WithOne(x => x.Transmission).HasForeignKey(x => x.TransmissionId);
        });
    }
}