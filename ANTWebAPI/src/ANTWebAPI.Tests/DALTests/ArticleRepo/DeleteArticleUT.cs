using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.Tests.DALTests.ArticleRepo;

public class DeleteArticleUT
{
    [Fact]
    public async Task SuccessDeleteArticle()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var article = await context.Articles.OrderBy(e => e.Id).LastOrDefaultAsync();// last article in the table isn't used as a foreign key in the article table
        Assert.NotNull(article);
        Assert.True(await repository.DeleteAsync(article.Id));
        var deletedArticle = await repository.GetModelAsync(article.Id);
        Assert.Null(deletedArticle);
    }
    [Fact]
    public async Task FailedDeleteArticleWithNonExistentEntity()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        Assert.False(await repository.DeleteAsync(78L));// trying to delete an article with non existent id
    }
    [Fact]
    public async Task FailedDeleteArticleThatWasUsedAsAForeignKeyInOtherEntityRecord()
    {
        using ANTDbContext context = new();
        var repository = new ArticleRepository(context);
        var article = await context.Articles.FirstOrDefaultAsync();// first article in the table is used as a foreign key in the article table
        Assert.NotNull(article);
        Assert.False(await repository.DeleteAsync(article.Id));
        var deletedArticle = await repository.GetModelAsync(article.Id);
        Assert.NotNull(deletedArticle);
    }
}
