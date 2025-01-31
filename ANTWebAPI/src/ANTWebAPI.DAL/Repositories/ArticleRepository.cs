using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Repositories;

public class ArticleRepository(ANTDbContext antDbContext) : IRepository<Article>
{
    public async Task<bool> DeleteAsync(long id)
    {
        if (await antDbContext.Contents.AnyAsync(e => e.ArticleId == id)) return false;
        var model = await antDbContext.Articles.FirstOrDefaultAsync(e => e.Id == id);
        if (model == null) return false;
        antDbContext.Articles.Remove(model);
        await antDbContext.SaveChangesAsync();
        return true;
    }
    public async Task<List<Article>> GetListAsync() => await antDbContext.Articles.AsNoTracking().Include(e => e.Catalog).ToListAsync();
    public async Task<Article?> GetModelAsync(long id) => await antDbContext.Articles.AsNoTracking().Include(e => e.Catalog).FirstOrDefaultAsync(e => e.Id == id);
    public async Task InsertAsync(Article model)
    {
        await antDbContext.Articles.AddAsync(model);
        await antDbContext.SaveChangesAsync();
    }
    public async Task<bool> IsEntityExistsAsync(long id) => await antDbContext.Articles.AnyAsync(e => e.Id == id);
    public async Task<bool> UpdateAsync(Article model)
    {
        antDbContext.Entry(model).State = EntityState.Modified;
        try
        {
            await antDbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
        }
        return true;
    }
}
