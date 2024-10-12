using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.DALTests.ContentRepo;

public class DeleteContentUT
{
    [Fact]
    public async Task SuccessDeleteContent()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var content = await context.Contents.OrderBy(e => e.Id).LastOrDefaultAsync();
        Assert.NotNull(content);
        Assert.True(await repository.DeleteAsync(content.Id));
        var deletedContent = await repository.GetModelAsync(content.Id);
        Assert.Null(deletedContent);
    }
    [Fact]
    public async Task FailedDeleteContent()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        Assert.False(await repository.DeleteAsync(78L));// trying to delete a content with non existent id
    }
}
