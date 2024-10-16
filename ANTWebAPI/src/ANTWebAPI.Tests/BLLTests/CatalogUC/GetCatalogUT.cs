using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.BLLTests.CatalogUC;

public class GetCatalogUT
{
    [Fact]
    public async Task SuccessGetCatalog()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var useCases = new CatalogUseCases(repository);
        var anyCatalog = await context.Catalogs.FirstOrDefaultAsync();
        Assert.NotNull(anyCatalog);
        var foundCatalog = await useCases.GetAsync(anyCatalog.Id);
        Assert.NotNull(foundCatalog);
        Assert.Equal(anyCatalog.Name, foundCatalog.Name);
    }
    [Fact]
    public async Task FailedGetCatalog()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var useCases = new CatalogUseCases(repository);
        var foundCatalog = await useCases.GetAsync(4378L);
        Assert.Null(foundCatalog);
    }
    [Fact]
    public async Task GetCatalogs()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var useCases = new CatalogUseCases(repository);
        var catalogs = await useCases.GetListAsync();
        Assert.NotNull(catalogs);
        Assert.NotEmpty(catalogs);
        Assert.True(catalogs.Count > 0);
    }
}
