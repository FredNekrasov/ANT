using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Repositories;

/*
 * ArticleRepository is used for Article CRUD operations and other
 */
public class ArticleRepository(ANTDbContext context) : IRepository<Article>
{
    private readonly ANTDbContext _context = context;
    /*
     * Delete Article method is used for deleting Article
     * 
     * @param id - Article id
     * 
     * @return bool - true if deleted else false
     */
    public async Task<bool> DeleteAsync(long id)
    {
        if (await _context.Contents.AnyAsync(e => e.ArticleId == id)) return false;
        var model = await _context.Articles.FirstOrDefaultAsync(e => e.Id == id);
        if (model == null) return false;
        _context.Articles.Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }
    /*
     * Get Article List method is used for getting Article List
     * 
     * @return List<Article> - Article List
     */
    public async Task<List<Article>> GetListAsync()
    {
        List<Article> articleModels = [];
        var articles = await _context.Articles.ToListAsync();
        foreach (var article in articles)
        {
            var catalog = await _context.Catalogs.FirstOrDefaultAsync(e => e.Id == article.CatalogId);
            if (catalog == null) continue;
            var articleModel = new Article
            {
                Id = article.Id,
                Catalog = catalog,
                Title = article.Title,
                Description = article.Description,
                DateOrBanner = article.DateOrBanner
            };
            articleModels.Add(articleModel);
        }
        return articleModels;
    }
    /*
     * Get Article method is used for getting Article
     * 
     * @param id - Article id
     * 
     * @return Article? - Article if record with given id exists else null
     */
    public async Task<Article?> GetModelAsync(long id) => await _context.Articles.FirstOrDefaultAsync(e => e.Id == id);
    /*
     * Insert Article method is used for inserting Article
     * 
     * @param model - Article
     * 
     * @returns nothing
     */
    public async Task InsertAsync(Article model)
    {
        await _context.Articles.AddAsync(model);
        await _context.SaveChangesAsync();
    }
    /*
     * IsEntityExists method is used for checking if entity exists
     * 
     * @param id - Article id
     * 
     * @returns bool - true if exists else false
     */
    public async Task<bool> IsEntityExistsAsync(long id) => await _context.Articles.AnyAsync(e => e.Id == id);
    /*
     * Update Article method is used for updating Article
     * 
     * @param model - Article
     * 
     * @returns bool - true if updated else false
     */
    public async Task<bool> UpdateAsync(Article model)
    {
        _context.Entry(model).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
        }
        return true;
    }
}
