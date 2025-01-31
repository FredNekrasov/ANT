using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Repositories;

public class ChapterRepository(ANTDbContext antDbContext) : IChapterRepository
{
    
    public async Task<List<Chapter>> GetListAsync()
    {
        var articles = await antDbContext.Articles.AsNoTracking()
            .Include(e => e.Catalog)
            .ToListAsync();
        var contentList = await antDbContext.Contents.AsNoTracking().ToListAsync();
        return GetChaptersAsync(articles, contentList);
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
    public async Task<List<Chapter>> GetPagedListByCatalogAsync(long catalogId, int pageNumber, int pageSize)
    {
        if (!await antDbContext.Catalogs.AnyAsync(e => e.Id == catalogId)) return [];
        var contentList = await antDbContext.Contents.AsNoTracking().ToListAsync();
        if (catalogId == 1)
        {
            var mainArticles = await antDbContext.Articles.AsNoTracking()
                .Where(e => e.CatalogId != 2 && e.CatalogId != 5 && e.CatalogId != 7 && e.CatalogId != 8 && e.CatalogId != 13)
                .Include(e => e.Catalog)
                .ToListAsync();
            return GetChaptersAsync(mainArticles, contentList);
        }
        var articles = await antDbContext.Articles.AsNoTracking()
            .Where(e => e.CatalogId == catalogId)
            .Include(e => e.Catalog)
            .ToListAsync();
        var chapterList = GetChaptersAsync(articles, contentList);
        int startIndex = (pageNumber - 1) * pageSize, endIndex = startIndex + pageSize;
        return articles.Count < pageSize ? chapterList : chapterList.Take(startIndex..endIndex).ToList();
    }
    
    public async Task<int> GetTotalCountAsync() => await antDbContext.Articles.CountAsync();
    
    List<Chapter> GetChaptersAsync(List<Article> articles, List<Content> contentList)
    {
        List<Chapter> chapterList = [];
        chapterList.AddRange(
            from article in articles
            let content = contentList.Where(content => content.ArticleId == article.Id)
                .Select(content => content.Data)
                .ToList()
            select new Chapter
            {
                Id = article.Id,
                Catalog = article.Catalog,
                Title = article.Title,
                Description = article.Description,
                DateOrBanner = article.DateOrBanner,
                Content = content
            }
        );
        return chapterList;
    }
}
