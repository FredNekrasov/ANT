using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;

namespace ANTWebAPI.PL.mappers;

public static class ChapterMapper
{
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
