using ANTWebAPI.BLL.Models;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.DALTests.ContentRepo;

public class InsertContentUT
{
    [Fact]
    public async Task SuccessInsertContentAsync()
    {
        // need to specify an existing articleId
        var content = new Content() { ArticleId = 2, Data = "Test" };
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        await repository.InsertAsync(content);
        var insertedContent = await repository.GetModelAsync(content.Id);
        Assert.NotNull(insertedContent);
        Assert.Equal(content.Data, insertedContent.Data);
    }
    [Fact]
    public async Task InsertEmptyContentAsync()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        await Assert.ThrowsAsync<DbUpdateException>(() => repository.InsertAsync(new Content()));
        var insertedContent = await context.Contents.FirstOrDefaultAsync(e => e.Data == string.Empty);
        Assert.Null(insertedContent);
    }
    [Fact]
    public async Task FailedInsertContentAsync()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        await Assert.ThrowsAsync<DbUpdateException>(() => repository.InsertAsync(new Content() { Id = 1, ArticleId = 1, Data = "InsertContentTest" }));
        var insertedContent = await context.Contents.FirstOrDefaultAsync(e => e.Data == "InsertContentTest");
        Assert.Null(insertedContent);
    }
}
