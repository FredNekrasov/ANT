using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;

namespace ANTWebAPI.PL.mappers;

public static class ArticleMapper
{
    public static ArticleDTO ToDto(this Article article) => new()
    {
        Id = article.Id,
        Title = article.Title,
        Catalog = article.Catalog.ToDto(),
        Description = article.Description,
        DateOrBanner = article.DateOrBanner
    };

    public static Article ToModel(this ArticleDTO articleDto) => new()
    {
        Id = articleDto.Id,
        Title = articleDto.Title,
        CatalogId = articleDto.Catalog.Id,
        Description = articleDto.Description,
        DateOrBanner = articleDto.DateOrBanner
    };
}
