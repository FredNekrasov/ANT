using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;

namespace ANTWebAPI.PL.mappers;

internal static class ArticleMapper
{
    internal static ArticleDTO ToDto(this Article article) => new()
    {
        Id = article.Id,
        Title = article.Title,
        Catalog = article.Catalog.ToDto(),
        Description = article.Description,
        DateOrBanner = article.DateOrBanner
    };

    internal static Article ToModel(this ArticleDTO article) => new()
    {
        Id = article.Id,
        Title = article.Title,
        CatalogId = article.Catalog.Id,
        Description = article.Description,
        DateOrBanner = article.DateOrBanner
    };
}
