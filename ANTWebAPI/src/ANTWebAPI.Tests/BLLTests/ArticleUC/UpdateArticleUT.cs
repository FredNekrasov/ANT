using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.BLLTests.ArticleUC;

public class UpdateArticleUT
{
    [Fact]
    public async Task SuccessUpdateArticleAsync()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var useCases = new ArticleUseCases(repository);
        var article = await context.Articles.OrderBy(e => e.Id).LastOrDefaultAsync();
        Assert.NotNull(article);
        article.Title = "Updated Article(BLL)";
        Assert.True(await useCases.UpdateAsync(article.Id, article));
        var updatedArticle = await repository.GetModelAsync(article.Id);
        Assert.NotNull(updatedArticle);
        Assert.Equal(article.Title, updatedArticle.Title);
    }
    [Fact]
    public async Task FailedUpdateArticleAsync()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var useCases = new ArticleUseCases(repository);
        var article = new BLL.Models.Article() { Id = -1, Title = "TestUpdateArticle(BLL)", CatalogId = 1, Description = "TestUpdateArticle(BLL)", DateOrBanner = DateTime.Today.ToString() };
        Assert.False(await useCases.UpdateAsync(article.Id, article));
        Assert.False(await useCases.UpdateAsync(778899L, article));
        article.Id = 778899L;
        Assert.Null(await useCases.UpdateAsync(article.Id, article));
    }
}
