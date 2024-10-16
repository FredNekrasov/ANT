using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.DALTests.CatalogRepo;

public class UpdateCatalogUT
{
    [Fact]
    public async Task SuccessUpdateCatalogAsync()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var catalog = await context.Catalogs.OrderBy(e => e.Id).LastOrDefaultAsync();
        Assert.NotNull(catalog);
        catalog.Name = "Updated Catalog";
        await repository.UpdateAsync(catalog);
        var updatedCatalog = await repository.GetModelAsync(catalog.Id);
        Assert.NotNull(updatedCatalog);
        Assert.Equal(catalog.Name, updatedCatalog.Name);
    }
    [Fact]
    public async Task FailedUpdateCatalogAsync()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var catalog = new BLL.Models.Catalog() { Id = -1, Name = "TestUpdateCatalog" };
        Assert.False(await repository.UpdateAsync(catalog));
    }
}
