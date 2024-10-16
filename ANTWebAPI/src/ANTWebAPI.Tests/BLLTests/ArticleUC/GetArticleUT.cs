using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.BLLTests.ArticleUC;

public class GetArticleUT
{
    [Fact]
    public async Task SuccessGetArticle()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var useCases = new ArticleUseCases(repository);
        var anyArticle = await context.Articles.FirstOrDefaultAsync();
        Assert.NotNull(anyArticle);
        var foundArticle = await useCases.GetAsync(anyArticle.Id);
        Assert.NotNull(foundArticle);
        Assert.Equal(anyArticle.Title, foundArticle.Title);
    }
    [Fact]
    public async Task FailedGetArticle()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var useCases = new ArticleUseCases(repository);
        var foundArticle = await useCases.GetAsync(4378L);
        Assert.Null(foundArticle);
    }
    [Fact]
    public async Task GetArticles()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var useCases = new ArticleUseCases(repository);
        var articles = await useCases.GetListAsync();
        Assert.NotNull(articles);
        Assert.NotEmpty(articles);
        Assert.True(articles.Count > 0);
    }
}
