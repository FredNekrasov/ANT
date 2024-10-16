using ANTWebAPI.BLL.Models;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.DALTests.CatalogRepo;

public class InsertCatalogUT
{
    [Fact]
    public async Task SuccessInsertCatalogAsync()
    {
        var catalog = new Catalog() { Name = "Test" };
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        await repository.InsertAsync(catalog);
        var insertedCatalog = await repository.GetModelAsync(catalog.Id);
        Assert.NotNull(insertedCatalog);
        Assert.Equal(catalog.Name, insertedCatalog.Name);
    }
    [Fact]
    public async Task InsertEmptyCatalogAsync()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        await repository.InsertAsync(new Catalog());
        var insertedCatalog = await context.Catalogs.FirstOrDefaultAsync(e => e.Name == string.Empty);
        Assert.NotNull(insertedCatalog);
    }
    [Fact]
    public async Task FailedInsertCatalogAsync()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        await Assert.ThrowsAsync<DbUpdateException>(() => repository.InsertAsync(new Catalog() { Id = 1, Name = "InsertCatalogTest" }));
        var insertedCatalog = await context.Catalogs.FirstOrDefaultAsync(e => e.Name == "InsertCatalogTest");
        Assert.Null(insertedCatalog);
    }
}
