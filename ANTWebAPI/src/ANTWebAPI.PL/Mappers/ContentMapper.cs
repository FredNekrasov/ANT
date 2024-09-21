using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;

namespace ANTWebAPI.PL.mappers;

internal static class ContentMapper
{
    internal static ContentDTO ToDto(this Content content) => new()
    {
        Id = content.Id,
        ArticleId = content.ArticleId,
        Data = content.Data
    };

    internal static Content ToModel(this ContentDTO content) => new()
    {
        Id = content.Id,
        ArticleId = content.ArticleId,
        Data = content.Data
    };
}
