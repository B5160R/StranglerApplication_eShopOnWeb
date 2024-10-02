
using Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.EFCore.Context;

public partial class CatalogDbContext : DbContext
{
    public CatalogDbContext()
    {
    }

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatalogBrand> CatalogBrands { get; set; }

    public virtual DbSet<CatalogItem> CatalogItems { get; set; }

    public virtual DbSet<CatalogType> CatalogTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatalogBrand>(entity =>
        {
            entity.HasKey(x => x.Id);
        });

        modelBuilder.Entity<CatalogItem>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<CatalogType>(entity =>
        {
            entity.HasKey(x => x.Id);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
