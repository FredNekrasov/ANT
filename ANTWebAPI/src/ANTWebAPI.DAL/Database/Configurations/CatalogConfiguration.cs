using ANTWebAPI.BLL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Database.Configurations;

/*
 * CatalogConfiguration is a configuration class for the Catalog entity that configures the catalog table in the database.
 */
internal class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
{
    public void Configure(EntityTypeBuilder<Catalog> entity)
    {
        entity.ToTable("ANTCatalogs").HasKey(t => t.Id);
        entity.HasMany(i => i.Articles).WithOne(i => i.Catalog).HasForeignKey(i => i.CatalogId);
    }
}
