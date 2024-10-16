using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.DALTests.ArticleRepo;

public class GetArticleUT
{
    [Fact]
    public async Task SuccessGetArticle()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var anyArticle = await context.Articles.FirstOrDefaultAsync();
        Assert.NotNull(anyArticle);
        var foundArticle = await repository.GetModelAsync(anyArticle.Id);
        Assert.NotNull(foundArticle);
        Assert.Equal(anyArticle.Title, foundArticle.Title);
    }
    [Fact]
    public async Task FailedGetArticle()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var foundArticle = await repository.GetModelAsync(4378L);
        Assert.Null(foundArticle);
    }
    [Fact]
    public async Task GetArticles()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var articles = await repository.GetListAsync();
        Assert.NotNull(articles);
        Assert.NotEmpty(articles);
        Assert.True(articles.Count > 0);
    }
    [Fact]
    public async Task SuccessIsArticleExistsAsync()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var anyArticle = await context.Articles.FirstOrDefaultAsync();
        Assert.NotNull(anyArticle);
        Assert.True(await repository.IsEntityExistsAsync(anyArticle.Id));
    }
    [Fact]
    public async Task FailedIsArticleExistsAsync()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        Assert.False(await repository.IsEntityExistsAsync(4378L));
    }
}
