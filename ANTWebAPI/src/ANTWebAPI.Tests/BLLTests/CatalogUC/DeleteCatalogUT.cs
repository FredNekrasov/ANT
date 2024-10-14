using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.BLLTests.CatalogUC;

public class DeleteCatalogUT
{
    [Fact]
    public async Task SuccessDeleteCatalog()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var useCases = new CatalogUseCases(repository);
        var catalog = await context.Catalogs.OrderBy(e => e.Id).LastOrDefaultAsync();// last catalog in the table isn't used as a foreign key in the article table
        Assert.NotNull(catalog);
        Assert.True(await useCases.DeleteAsync(catalog.Id));
        var deletedCatalog = await useCases.GetAsync(catalog.Id);
        Assert.Null(deletedCatalog);
    }
    [Fact]
    public async Task FailedDeleteCatalogWithNonExistentEntity()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var useCases = new CatalogUseCases(repository);
        Assert.Null(await useCases.DeleteAsync(778899L));// trying to delete a catalog with non existent id
    }
    [Fact]
    public async Task FailedDeleteCatalogThatWasUsedAsAForeignKeyInOtherEntityRecord()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var useCases = new CatalogUseCases(repository);
        var catalog = await context.Catalogs.FirstOrDefaultAsync();// first catalog in the table is used as a foreign key in the article table
        Assert.NotNull(catalog);
        Assert.False(await useCases.DeleteAsync(catalog.Id));
        var deletedCatalog = await useCases.GetAsync(catalog.Id);
        Assert.NotNull(deletedCatalog);
    }
}
