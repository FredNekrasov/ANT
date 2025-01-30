using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Repositories;

public class ContentRepository(ANTDbContext antDbContext) : IRepository<Content>
{
    public async Task<bool> DeleteAsync(long id)
    {
        var model = await antDbContext.Contents.FirstOrDefaultAsync(e => e.Id == id);
        if (model == null) return false;
        antDbContext.Contents.Remove(model);
        await antDbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<List<Content>> GetListAsync() => await antDbContext.Contents.AsNoTracking().ToListAsync();
    
    public async Task<Content?> GetModelAsync(long id) => await antDbContext.Contents.FirstOrDefaultAsync(e => e.Id == id);
    
    public async Task InsertAsync(Content model)
    {
        await antDbContext.Contents.AddAsync(model);
        await antDbContext.SaveChangesAsync();
    }
    
    public async Task<bool> IsEntityExistsAsync(long id) => await antDbContext.Contents.AnyAsync(e => e.Id == id);
    
    public async Task<bool> UpdateAsync(Content model)
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
