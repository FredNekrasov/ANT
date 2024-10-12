using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.DALTests.ContentRepo;

public class GetContentUT
{
    [Fact]
    public async Task SuccessGetContent()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var anyContent = await context.Contents.FirstOrDefaultAsync();
        Assert.NotNull(anyContent);
        var foundContent = await repository.GetModelAsync(anyContent.Id);
        Assert.NotNull(foundContent);
        Assert.Equal(anyContent.Data, foundContent.Data);
    }
    [Fact]
    public async Task FailedGetContent()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var foundContent = await repository.GetModelAsync(4378L);
        Assert.Null(foundContent);
    }
    [Fact]
    public async Task GetContents()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var contentList = await repository.GetListAsync();
        Assert.NotNull(contentList);
        Assert.NotEmpty(contentList);
        Assert.True(contentList.Count > 0);
    }
    [Fact]
    public async Task SuccessIsContentExistsAsync()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var anyContent = await context.Contents.FirstOrDefaultAsync();
        Assert.NotNull(anyContent);
        Assert.True(await repository.IsEntityExistsAsync(anyContent.Id));
    }
    [Fact]
    public async Task FailedIsContentExistsAsync()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        Assert.False(await repository.IsEntityExistsAsync(4378L));
    }
}
