using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.DALTests.ContentRepo;

public class UpdateContentUT
{
    [Fact]
    public async Task SuccessUpdateContentAsync()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var content = await context.Contents.OrderBy(e => e.Id).LastOrDefaultAsync();
        Assert.NotNull(content);
        content.Data = "Updated Content";
        Assert.True(await repository.UpdateAsync(content));
        var updatedContent = await repository.GetModelAsync(content.Id);
        Assert.NotNull(updatedContent);
        Assert.Equal(content.Data, updatedContent.Data);
    }
    [Fact]
    public async Task FailedUpdateContentAsync()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var content = new BLL.Models.Content() { Id = -1, ArticleId = 2, Data = "TestUpdateContent" };
        Assert.False(await repository.UpdateAsync(content));
    }
}
