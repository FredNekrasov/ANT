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
        var contentList = await _context.Contents.ToListAsync();
        var articleList = await _context.Articles.ToListAsync();
        var chapterList = new List<Chapter>();
        foreach (var article in articleList)
        {
            var content = contentList.Where(content => content.ArticleId == article.Id).Select(content => content.Data).ToList();
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
