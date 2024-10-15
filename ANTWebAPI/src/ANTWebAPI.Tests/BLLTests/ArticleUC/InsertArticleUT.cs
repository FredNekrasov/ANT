using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.BLL.Utils;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.BLLTests.ArticleUC;

public class InsertArticleUT
{
    [Fact]
    public async Task SuccessInsertArticleAsync()
    {
        var article = new Article() { Title = "Test(BLL)", CatalogId = 1, Description = "Test(BLL)", DateOrBanner = DateTime.Today.ToString() };
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var useCases = new ArticleUseCases(repository);
        Assert.True(await useCases.InsertAsync(article));
    }
    [Fact]
    public async Task InsertEmptyArticleAsync()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var useCases = new ArticleUseCases(repository);
        Assert.False(await useCases.InsertAsync(new Article()));
    }
    [Fact]
    public async Task FailedInsertArticleAsync()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var useCases = new ArticleUseCases(repository);
        Assert.False(await useCases.InsertAsync(new Article() { Id = 1, Title = "InsertArticleTest(BLL)", CatalogId = 2, Description = "InsertArticleTest(BLL)", DateOrBanner = DateTime.Today.ToString() }));
    }
    [Fact]
    public void SuccessIsArticleValid()
    {
        var article = new Article() { Id = 1, Title = "InsertArticleTest(BLL)", CatalogId = 2, Description = "InsertArticleTest(BLL)", DateOrBanner = DateTime.Today.ToString() };
        Assert.True(article.IsDataValid());
    }
    [Fact]
    public void FailedIsArticleValid()
    {
        var article = new Article();
        Assert.False(article.IsDataValid());
    }
}
