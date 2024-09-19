﻿using ANTWebAPI.BLL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Database.Configurations;

internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> entity)
    {
        entity.ToTable("Articles").HasKey(t => t.Id);
        entity.Property(t => t.CatalogId).HasColumnName("catalog_id");
        entity.Property(t => t.DateOrBanner).HasColumnName("date_or_banner");
        entity.HasMany(t => t.Contents).WithOne(t => t.Article).HasForeignKey(t => t.ArticleId);
    }
}
