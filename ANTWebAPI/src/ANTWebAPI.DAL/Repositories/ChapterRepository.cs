using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Repositories;

public class ChapterRepository(ANTDbContext context) : IChapterRepository
{
    private readonly ANTDbContext _context = context;

    public async Task<List<Chapter>> GetListAsync()
    {
        var articles = await _context.Articles.ToListAsync();
        var chapterList = await GetChapterListAsync(articles);
        return chapterList;
    }
    public async Task<List<Chapter>> GetPagedListByCatalogAsync(int catalogId, int pageNumber, int pageSize)
    {
        if (!await _context.Catalogs.AnyAsync(e => e.Id == catalogId)) return [];
        var articles = await _context.Articles.Where(e => e.CatalogId == catalogId).ToListAsync();
        var chapterList = await GetChapterListAsync(articles);
        return articles.Count < 25 ? chapterList : chapterList.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
    public async Task<int> GetTotalCountAsync() => await _context.Articles.CountAsync();
    private async Task<List<Chapter>> GetChapterListAsync(List<Article> articles)
    {
        var chapterList = new List<Chapter>();
        foreach (var article in articles)
        {
            var content = await _context.Contents.Where(content => content.ArticleId == article.Id).Select(content => content.Data).ToListAsync();
            var catalog = await _context.Catalogs.FirstOrDefaultAsync(e => e.Id == article.CatalogId);
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
