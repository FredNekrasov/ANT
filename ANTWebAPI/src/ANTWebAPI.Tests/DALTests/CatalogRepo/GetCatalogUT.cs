using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.DALTests.CatalogRepo;

public class GetCatalogUT
{
    [Fact]
    public async Task SuccessGetCatalog()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var anyCatalog = await context.Catalogs.FirstOrDefaultAsync();
        Assert.NotNull(anyCatalog);
        var foundCatalog = await repository.GetModelAsync(anyCatalog.Id);
        Assert.NotNull(foundCatalog);
        Assert.Equal(anyCatalog.Name, foundCatalog.Name);
    }
    [Fact]
    public async Task FailedGetCatalog()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var foundCatalog = await repository.GetModelAsync(4378L);
        Assert.Null(foundCatalog);
    }
    [Fact]
    public async Task GetCatalogs()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var catalogs = await repository.GetListAsync();
        Assert.NotNull(catalogs);
        Assert.NotEmpty(catalogs);
        Assert.True(catalogs.Count > 0);
    }
    [Fact]
    public async Task SuccessIsCatalogExistsAsync()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var anyCatalog = await context.Catalogs.FirstOrDefaultAsync();
        Assert.NotNull(anyCatalog);
        Assert.True(await repository.IsEntityExistsAsync(anyCatalog.Id));
    }
    [Fact]
    public async Task FailedIsCatalogExistsAsync()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        Assert.False(await repository.IsEntityExistsAsync(4378L));
    }
}
