using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;

namespace ANTWebAPI.PL.mappers;

/*
 * ChapterMapper is used for extension methods to map Chapter in the ChapterDTO
 */
public static class ChapterMapper
{
    /*
     * ToDto is extension method that maps Chapter to ChapterDTO
     * 
     * @param chapter Chapter
     * 
     * @return ChapterDTO
     */
    public static ChapterDTO ToDto(this Chapter chapter) => new()
    {
        Id = chapter.Id,
        Catalog = chapter.Catalog.ToDto(),
        Title = chapter.Title,
        Description = chapter.Description,
        DateOrBanner = chapter.DateOrBanner,
        Content = chapter.Content
    };
}
