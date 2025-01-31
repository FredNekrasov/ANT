using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.BLLTests.ContentUC;

public class GetContentUT
{
    [Fact]
    public async Task SuccessGetContent()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var useCases = new ContentUseCases(repository);
        var anyContent = await context.Contents.FirstOrDefaultAsync();
        Assert.NotNull(anyContent);
        var foundContent = await useCases.GetRecordAsync(anyContent.Id);
        Assert.NotNull(foundContent);
        Assert.Equal(anyContent.Data, foundContent.Data);
    }
    [Fact]
    public async Task FailedGetContent()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var useCases = new ContentUseCases(repository);
        var foundContent = await useCases.GetRecordAsync(4378L);
        Assert.Null(foundContent);
    }
    [Fact]
    public async Task GetContents()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var useCases = new ContentUseCases(repository);
        var Contents = await useCases.GetListAsync();
        Assert.NotNull(Contents);
        Assert.NotEmpty(Contents);
        Assert.True(Contents.Count > 0);
    }
}
