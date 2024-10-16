using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.BLL.Utils;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.BLLTests.ContentUC;

public class InsertContentUT
{
    [Fact]
    public async Task SuccessInsertContentAsync()
    {
        // need to specify an existing articleId
        var content = new Content() { ArticleId = 2, Data = "InsertContentTest(BLL)" };
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var useCases = new ContentUseCases(repository);
        Assert.True(await useCases.InsertAsync(content));
    }
    [Fact]
    public async Task InsertEmptyContentAsync()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var useCases = new ContentUseCases(repository);
        Assert.False(await useCases.InsertAsync(new Content()));
    }
    [Fact]
    public async Task FailedInsertContentAsync()
    {
        using ANTDbContext context = new();
        var repository = new ContentRepository(context);
        var useCases = new ContentUseCases(repository);
        Assert.False(await useCases.InsertAsync(new Content() { Id = 1, ArticleId = 1, Data = "InsertContentTest(BLL)" }));
    }
    [Fact]
    public void SuccessIsContentValid()
    {
        var content = new Content() { Id = 1, ArticleId = 1, Data = "InsertContentTest(BLL)" };
        Assert.True(content.IsDataValid());
    }
    [Fact]
    public void FailedIsContentValid()
    {
        var content = new Content();
        Assert.False(content.IsDataValid());
    }
}
