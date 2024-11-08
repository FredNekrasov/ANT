using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;

namespace ANTWebAPI.PL.mappers;

/*
 * Article mapper is used for extension methods to map ArticleDTO in the Article model and vice versa
 */
public static class ArticleMapper
{
    /*
     * ToDto is extension method which returns ArticleDTO from Article
     * 
     * @param article
     * 
     * @return ArticleDTO
     */
    public static ArticleDTO ToDto(this Article article) => new()
    {
        Id = article.Id,
        Title = article.Title,
        Catalog = article.Catalog.ToDto(),
        Description = article.Description,
        DateOrBanner = article.DateOrBanner
    };
    /*
     * ToModel is extension method which returns Article from ArticleDTO
     * 
     * @param articleDto
     * 
     * @return Article
     */
    public static Article ToModel(this ArticleDTO articleDto) => new()
    {
        Id = articleDto.Id,
        Title = articleDto.Title,
        CatalogId = articleDto.Catalog.Id,
        Description = articleDto.Description,
        DateOrBanner = articleDto.DateOrBanner
    };
}
