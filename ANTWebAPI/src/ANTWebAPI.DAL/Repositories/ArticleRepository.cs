using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Repositories;

public class ArticleRepository(ANTDbContext context) : IRepository<Article>
{
    private readonly ANTDbContext _context = context;

    public async Task<bool> DeleteAsync(long id)
    {
        if (await _context.Contents.AnyAsync(e => e.ArticleId == id)) return false;
        var model = await _context.Articles.FirstOrDefaultAsync(e => e.Id == id);
        if (model == null) return false;
        _context.Articles.Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }

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

    public async Task<Article?> GetModelAsync(long id) => await _context.Articles.FirstOrDefaultAsync(e => e.Id == id);

    public async Task InsertAsync(Article model)
    {
        await _context.Articles.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsEntityExistsAsync(long id) => await _context.Articles.AnyAsync(e => e.Id == id);

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
