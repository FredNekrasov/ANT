using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.BLLTests.ContentUC;

public class DeleteContentUT
{
    [Fact]
    public async Task SuccessDeleteContent()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var useCases = new ContentUseCases(repository);
        var content = await context.Contents.OrderBy(e => e.Id).LastOrDefaultAsync();
        Assert.NotNull(content);
        Assert.True(await useCases.DeleteAsync(content.Id));
        var deletedContent = await useCases.GetRecordAsync(content.Id);
        Assert.Null(deletedContent);
    }
    [Fact]
    public async Task FailedDeleteContent()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var useCases = new ContentUseCases(repository);
        Assert.False(await repository.DeleteAsync(7788L));// trying to delete a content with non existent id
    }
}
