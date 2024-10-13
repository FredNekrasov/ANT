using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;

namespace ANTWebAPI.Tests.PLTests.Mappers;

public class CatalogMapperUT
{
    [Fact]
    public void MapToCatalog()
    {
        var catalogDto = new CatalogDTO() { Id = 1, Name = "Catalog" };
        Assert.NotNull(catalogDto.ToModel());
    }
    [Fact]
    public void MapToCatalogDTO()
    {
        var catalog = new Catalog() { Id = 1, Name = "Catalog" };
        Assert.NotNull(catalog.ToDto());
    }
}
