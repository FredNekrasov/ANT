using ANTWebAPI.BLL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Database.Configurations;

/*
 * ContentConfiguration is a configuration class for the Content entity that configures the content table in the database.
 */
internal class ContentConfiguration : IEntityTypeConfiguration<Content>
{
    public void Configure(EntityTypeBuilder<Content> entity)
    {
        entity.ToTable("ANTContents").HasKey(t => t.Id);
        entity.Property(t => t.ArticleId).HasColumnName("article_id");
    }
}
