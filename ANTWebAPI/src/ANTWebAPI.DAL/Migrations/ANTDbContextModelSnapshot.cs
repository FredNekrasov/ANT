﻿// <auto-generated />
using ANTWebAPI.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ANTWebAPI.DAL.Migrations
{
    [DbContext(typeof(ANTDbContext))]
    partial class ANTDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ANTWebAPI.BLL.Models.Article", b =>
                {
                    b.Property<long>("Id").ValueGeneratedOnAdd().HasColumnType("bigint");
                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CatalogId").HasColumnType("bigint").HasColumnName("catalog_id");
                    b.Property<string>("DateOrBanner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("date_or_banner");
                    b.Property<string>("Description").IsRequired().HasColumnType("nvarchar(max)");
                    b.Property<string>("Title").IsRequired().HasColumnType("nvarchar(max)");
                    b.HasKey("Id");
                    b.HasIndex("CatalogId");
                    b.ToTable("ANTArticles", (string)null);
                });

            modelBuilder.Entity("ANTWebAPI.BLL.Models.Catalog", b =>
                {
                    b.Property<long>("Id").ValueGeneratedOnAdd().HasColumnType("bigint");
                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name").IsRequired().HasColumnType("nvarchar(max)");
                    b.HasKey("Id");
                    b.ToTable("ANTCatalogs", (string)null);
                });

            modelBuilder.Entity("ANTWebAPI.BLL.Models.Content", b =>
                {
                    b.Property<long>("Id").ValueGeneratedOnAdd().HasColumnType("bigint");
                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ArticleId").HasColumnType("bigint").HasColumnName("article_id");
                    b.Property<string>("Data").IsRequired().HasColumnType("nvarchar(max)");
                    b.HasKey("Id");
                    b.HasIndex("ArticleId");
                    b.ToTable("ANTContents", (string)null);
                });

            modelBuilder.Entity("ANTWebAPI.BLL.Models.Article", b =>
                {
                    b.HasOne("ANTWebAPI.BLL.Models.Catalog", "Catalog")
                        .WithMany("Articles")
                        .HasForeignKey("CatalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catalog");
                });

            modelBuilder.Entity("ANTWebAPI.BLL.Models.Content", b =>
                {
                    b.HasOne("ANTWebAPI.BLL.Models.Article", "Article")
                        .WithMany("Contents")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("ANTWebAPI.BLL.Models.Article", b => { b.Navigation("Contents"); });
            modelBuilder.Entity("ANTWebAPI.BLL.Models.Catalog", b => { b.Navigation("Articles"); });
#pragma warning restore 612, 618
        }
    }
}