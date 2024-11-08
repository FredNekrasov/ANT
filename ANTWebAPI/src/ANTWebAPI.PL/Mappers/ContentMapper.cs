using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;

namespace ANTWebAPI.PL.mappers;

/*
 * Content mapper is used for extension methods to map ContentDTO in the Content model and vice versa
 */
public static class ContentMapper
{
    /*
     * ToDto is extension method that maps Content model to ContentDTO
     * 
     * @param content Content model
     * 
     * @return ContentDTO
     */
    public static ContentDTO ToDto(this Content content) => new()
    {
        Id = content.Id,
        ArticleId = content.ArticleId,
        Data = content.Data
    };
    /*
     * ToModel is extension method that maps ContentDTO to Content model
     * 
     * @param contentDto ContentDTO
     * 
     * @return Content
     */
    public static Content ToModel(this ContentDTO contentDto) => new()
    {
        Id = contentDto.Id,
        ArticleId = contentDto.ArticleId,
        Data = contentDto.Data
    };
}
