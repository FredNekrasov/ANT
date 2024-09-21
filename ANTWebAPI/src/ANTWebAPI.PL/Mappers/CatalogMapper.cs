using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;

namespace ANTWebAPI.PL.mappers;

internal static class CatalogMapper
{
    internal static CatalogDTO ToDto(this Catalog catalog) => new()
    {
        Id = catalog.Id,
        Name = catalog.Name
    };

    internal static Catalog ToModel(this CatalogDTO catalog) => new()
    {
        Id = catalog.Id,
        Name = catalog.Name
    };
}
