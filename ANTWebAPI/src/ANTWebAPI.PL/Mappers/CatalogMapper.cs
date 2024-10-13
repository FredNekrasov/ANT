using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;

namespace ANTWebAPI.PL.mappers;

public static class CatalogMapper
{
    public static CatalogDTO ToDto(this Catalog catalog) => new()
    {
        Id = catalog.Id,
        Name = catalog.Name
    };

    public static Catalog ToModel(this CatalogDTO catalogDto) => new()
    {
        Id = catalogDto.Id,
        Name = catalogDto.Name
    };
}
