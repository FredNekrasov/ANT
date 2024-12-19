using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Repositories;

/*
 * ChapterRepository is used for getting Chapter List
 */
public class ChapterRepository(ANTDbContext context) : IChapterRepository
{
    private readonly ANTDbContext _context = context;
    /*
     * GetListAsync method is used for getting Chapter List
     * 
     * @return List<Chapter> - Chapter List
     */
    public async Task<List<Chapter>> GetListAsync()
    {
        var articles = await _context.Articles.ToListAsync();
        var chapterList = await GetChapterListAsync(articles);
        return chapterList;
    }
    /*
     * GetPagedListByCatalogAsync method is used for getting Chapter List by Catalog id with pagination
     * 
     * @param catalogId - Catalog id 
     * @param pageNumber - Page number is used to get specific page of data
     * @param pageSize - Page size/number of items
     * 
     * @return List<Chapter> - Chapter List
     */
    public async Task<List<Chapter>> GetPagedListByCatalogAsync(int catalogId, int pageNumber, int pageSize)
    {
        if (!await _context.Catalogs.AnyAsync(e => e.Id == catalogId)) return [];
        if (catalogId == 1)
        {
            var mainArticles = await _context.Articles.Where(e => e.CatalogId != 2 && e.CatalogId != 5 && e.CatalogId != 7 && e.CatalogId != 8 && e.CatalogId != 13).ToListAsync();
            var mainChapterList = await GetChapterListAsync(mainArticles);
            return mainChapterList;
        }
        var articles = await _context.Articles.Where(e => e.CatalogId == catalogId).ToListAsync();
        var chapterList = await GetChapterListAsync(articles);
        return articles.Count < pageSize ? chapterList : chapterList.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
    /*
     * GetTotalCountAsync method is used for getting total number of chapters
     * 
     * @return int - Total number of chapters
     */
    public async Task<int> GetTotalCountAsync() => await _context.Articles.CountAsync();
    /*
     * GetChapterListAsync method is used for getting Chapter List
     * 
     * @param articles - List of Article
     * 
     * @return List<Chapter> - Chapter List
     */
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
