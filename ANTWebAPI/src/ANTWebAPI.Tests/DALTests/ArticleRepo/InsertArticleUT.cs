using ANTWebAPI.BLL.Models;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.DALTests.ArticleRepo;

public class InsertArticleUT
{
    [Fact]
    public async Task SuccessInsertArticleAsync()
    {
        var article = new Article() { Title = "Test", CatalogId = 1, Description = "Test", DateOrBanner = DateTime.Now.ToString() };
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        await repository.InsertAsync(article);
        var insertedArticle = await repository.GetModelAsync(article.Id);
        Assert.NotNull(insertedArticle);
        Assert.Equal(article.Title, insertedArticle.Title);
    }
    [Fact]
    public async Task InsertEmptyArticleAsync()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        await Assert.ThrowsAsync<DbUpdateException>(() => repository.InsertAsync(new Article()));
        var insertedArticle = await context.Articles.FirstOrDefaultAsync(e => e.Title == string.Empty);
        Assert.Null(insertedArticle);
    }
    [Fact]
    public async Task FailedInsertArticleAsync()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        await Assert.ThrowsAsync<DbUpdateException>(() => repository.InsertAsync(new Article() { Id = 1, Title = "InsertArticleTest", CatalogId = 22, Description = "InsertArticleTest", DateOrBanner = DateTime.Now.ToString() }));
        var insertedArticle = await context.Articles.FirstOrDefaultAsync(e => e.Title == "InsertArticleTest");
        Assert.Null(insertedArticle);
    }
}
