using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.BLLTests.ContentUC;

public class UpdateContentUT
{
    [Fact]
    public async Task SuccessUpdateContentAsync()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var useCases = new ContentUseCases(repository);
        var content = await context.Contents.OrderBy(e => e.Id).LastOrDefaultAsync();
        Assert.NotNull(content);
        content.Data = "Updated Content(BLL)";
        Assert.True(await useCases.UpdateAsync(content.Id, content));
        var updatedContent = await useCases.GetRecordAsync(content.Id);
        Assert.NotNull(updatedContent);
        Assert.Equal(content.Data, updatedContent.Data);
    }
    [Fact]
    public async Task FailedUpdateContentAsync()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var useCases = new ContentUseCases(repository);
        var content = new BLL.Models.Content() { Id = -1, ArticleId = 2, Data = "TestUpdateContent(BLL)" };
        Assert.False(await useCases.UpdateAsync(content.Id, content));
        Assert.False(await useCases.UpdateAsync(778899L, content));
        content.Id = 778899L;
        Assert.Null(await useCases.UpdateAsync(content.Id, content));
    }
}
