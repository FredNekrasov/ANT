using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;

namespace ANTWebAPI.Tests.PLTests.Mappers;

public class ArticleMapperUT
{
    [Fact]
    public void MapToArticle()
    {
        var articleDto = new ArticleDTO()
        {
            Id = 1,
            Catalog = new CatalogDTO() { Id = 1, Name = "Catalog" },
            Title = "Title",
            DateOrBanner = DateTime.Today.ToString(),
            Description = "Description"
        };
        Assert.NotNull(articleDto.ToModel());
    }
    [Fact]
    public void MapToArticleDTO()
    {
        var article = new Article()
        {
            Id = 1,
            Catalog = new Catalog() { Id = 1, Name = "Catalog" },
            Title = "Title",
            DateOrBanner = DateTime.Today.ToString(),
            Description = "Description"
        };
        Assert.NotNull(article.ToDto());
    }
}
