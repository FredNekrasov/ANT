using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;

namespace ANTWebAPI.PL.mappers;

/*
 * Catalog mapper is used for extension methods to map CatalogDTO in the Catalog and vice versa
 */
public static class CatalogMapper
{
    /*
     * ToDto is extension method that maps Catalog to CatalogDTO
     * 
     * @param catalog
     * 
     * @return CatalogDTO
     */
    public static CatalogDTO ToDto(this Catalog catalog) => new()
    {
        Id = catalog.Id,
        Name = catalog.Name
    };
    /*
     * ToModel is extension method that maps CatalogDTO to Catalog
     * 
     * @param catalogDto
     * 
     * @return Catalog
     */
    public static Catalog ToModel(this CatalogDTO catalogDto) => new()
    {
        Id = catalogDto.Id,
        Name = catalogDto.Name
    };
}
