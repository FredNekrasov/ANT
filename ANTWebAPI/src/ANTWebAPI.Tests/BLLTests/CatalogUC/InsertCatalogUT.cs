using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.BLL.Utils;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;

namespace ANTWebAPI.Tests.BLLTests.CatalogUC;

public class InsertCatalogUT
{
    [Fact]
    public async Task SuccessInsertCatalogAsync()
    {
        var catalog = new Catalog() { Name = "BLLTest" };
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var useCases = new CatalogUseCases(repository);
        Assert.True(await useCases.InsertAsync(catalog));
    }
    [Fact]
    public async Task InsertEmptyCatalogAsync()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var useCases = new CatalogUseCases(repository);
        Assert.False(await useCases.InsertAsync(new Catalog()));
    }
    [Fact]
    public async Task FailedInsertCatalogAsync()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var useCases = new CatalogUseCases(repository);
        Assert.False(await useCases.InsertAsync(new Catalog() { Id = 1, Name = "InsertCatalogTest(BLL)" }));
    }
    [Fact]
    public void SuccessIsCatalogValid()
    {
        var catalog = new Catalog() { Name = "InsertCatalogTest(BLL)" };
        Assert.True(catalog.IsDataValid());
    }
    [Fact]
    public void FailedIsCatalogValid()
    {
        var catalog = new Catalog();
        Assert.False(catalog.IsDataValid());
    }
}
