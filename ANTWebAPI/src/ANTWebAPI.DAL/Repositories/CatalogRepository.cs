using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Repositories;

public class CatalogRepository(ANTDbContext antDbContext) : IRepository<Catalog>
{
    public async Task<bool> DeleteAsync(long id)
    {
        if (await antDbContext.Articles.AnyAsync(e => e.CatalogId == id)) return false;
        var model = await antDbContext.Catalogs.FirstOrDefaultAsync(e => e.Id == id);
        if (model == null) return false;
        antDbContext.Catalogs.Remove(model);
        await antDbContext.SaveChangesAsync();
        return true;
    }
    public async Task<List<Catalog>> GetListAsync() => await antDbContext.Catalogs.AsNoTracking().ToListAsync();
    public async Task<Catalog?> GetModelAsync(long id) => await antDbContext.Catalogs.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    public async Task InsertAsync(Catalog model)
    {
        await antDbContext.Catalogs.AddAsync(model);
        await antDbContext.SaveChangesAsync();
    }
    public async Task<bool> IsEntityExistsAsync(long id) => await antDbContext.Catalogs.AnyAsync(e => e.Id == id);
    public async Task<bool> UpdateAsync(Catalog model)
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
