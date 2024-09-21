using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;

namespace ANTWebAPI.PL.mappers;

internal static class ChapterMapper
{
    internal static ChapterDTO ToDto(this Chapter chapter) => new()
    {
        Id = chapter.Id,
        Catalog = chapter.Catalog.ToDto(),
        Title = chapter.Title,
        Description = chapter.Description,
        DateOrBanner = chapter.DateOrBanner,
        Content = chapter.Content
    };
}
