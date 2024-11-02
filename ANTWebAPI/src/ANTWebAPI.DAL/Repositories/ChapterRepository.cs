using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Repositories;

public class ChapterRepository(ANTDbContext context) : IChapterRepository
{
    private readonly ANTDbContext _context = context;

    public async Task<List<Chapter>> GetListAsync() => await GetChapterListAsync(await _context.Articles.ToListAsync());
    public async Task<List<Chapter>> GetPagedListAsync(int pageNumber, int pageSize)
    {
        var query = _context.Articles.AsQueryable();
        var articles = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return await GetChapterListAsync(articles);
    }
    public async Task<int> GetTotalCountAsync() => await _context.Articles.CountAsync();
    private async Task<List<Chapter>> GetChapterListAsync(List<Article> articles)
    {
        var chapterList = new List<Chapter>();
        foreach (var article in articles)
        {
            var content = await _context.Contents.Where(content => content.ArticleId == article.Id).Select(content => content.Data).ToListAsync();
            var catalog = await _context.Catalogs.FindAsync(article.CatalogId);
            var chapter = new Chapter
            {
                Id = article.Id,
                Catalog = catalog ?? article.Catalog,
                Title = article.Title,
                Description = article.Description,
                DateOrBanner = article.DateOrBanner,
                Content = content
            };
            chapterList.Add(chapter);
        }
        return chapterList;
    }
}
