using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.DALTests.ArticleRepo;

public class UpdateArticleUT
{
    [Fact]
    public async Task SuccessUpdateArticleAsync()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var article = await context.Articles.OrderBy(e => e.Id).LastOrDefaultAsync();
        Assert.NotNull(article);
        article.Title = "Updated Article";
        await repository.UpdateAsync(article);
        var updatedArticle = await repository.GetModelAsync(article.Id);
        Assert.NotNull(updatedArticle);
        Assert.Equal(article.Title, updatedArticle.Title);
    }
    [Fact]
    public async Task FailedUpdateArticleAsync()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var article = new BLL.Models.Article() { Id = -1, Title = "TestUpdateArticle", CatalogId = 1, Description = "TestUpdateArticle", DateOrBanner = DateTime.Today.ToString() };
        Assert.False(await repository.UpdateAsync(article));
    }
}
