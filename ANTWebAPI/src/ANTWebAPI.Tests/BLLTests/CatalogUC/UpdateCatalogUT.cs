using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.BLLTests.CatalogUC;

public class UpdateCatalogUT
{
    [Fact]
    public async Task SuccessUpdateCatalogAsync()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var useCases = new CatalogUseCases(repository);
        var catalog = await context.Catalogs.OrderBy(e => e.Id).LastOrDefaultAsync();
        Assert.NotNull(catalog);
        catalog.Name = "Updated Catalog";
        Assert.True(await useCases.UpdateAsync(catalog.Id, catalog));
        var updatedCatalog = await useCases.GetAsync(catalog.Id);
        Assert.NotNull(updatedCatalog);
        Assert.Equal(catalog.Name, updatedCatalog.Name);
    }
    [Fact]
    public async Task FailedUpdateCatalogAsync()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var useCases = new CatalogUseCases(repository);
        var catalog = new BLL.Models.Catalog() { Id = -1, Name = "TestUpdateCatalog(BLL)" };
        Assert.False(await useCases.UpdateAsync(778899L, catalog));
        Assert.False(await useCases.UpdateAsync(catalog.Id, catalog));
        catalog.Id = 778899L;
        Assert.Null(await useCases.UpdateAsync(catalog.Id, catalog));
    }
}
