using ANTWebAPI.BLL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Database.Configurations;

internal class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
{
    public void Configure(EntityTypeBuilder<Catalog> entity)
    {
        entity.ToTable("ANTCatalogs").HasKey(t => t.Id);
        entity.HasMany(i => i.Articles).WithOne(i => i.Catalog).HasForeignKey(i => i.CatalogId);
    }
}
