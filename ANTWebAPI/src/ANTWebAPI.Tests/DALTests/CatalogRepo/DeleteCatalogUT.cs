using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.DALTests.CatalogRepo;

public class DeleteCatalogUT
{
    [Fact]
    public async Task SuccessDeleteCatalog()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var catalog = await context.Catalogs.OrderBy(e => e.Id).LastOrDefaultAsync();// last catalog in the table isn't used as a foreign key in the article table
        Assert.NotNull(catalog);
        Assert.True(await repository.DeleteAsync(catalog.Id));
        var deletedCatalog = await repository.GetModelAsync(catalog.Id);
        Assert.Null(deletedCatalog);
    }
    [Fact]
    public async Task FailedDeleteCatalogWithNonExistentEntity()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        Assert.False(await repository.DeleteAsync(78L));// trying to delete a catalog with non existent id
    }
    [Fact]
    public async Task FailedDeleteCatalogThatWasUsedAsAForeignKeyInOtherEntityRecord()
    {
        using ANTDbContext context = new();
        var repository = new CatalogRepository(context);
        var catalog = await context.Catalogs.FirstOrDefaultAsync();// first catalog in the table is used as a foreign key in the article table
        Assert.NotNull(catalog);
        Assert.False(await repository.DeleteAsync(catalog.Id));
        var deletedCatalog = await repository.GetModelAsync(catalog.Id);
        Assert.NotNull(deletedCatalog);
    }
}
