using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Repositories;

public class ContentRepository(ANTDbContext context) : IRepository<Content>
{
    private readonly ANTDbContext _context = context;

    public async Task<bool> DeleteAsync(long id)
    {
        var model = await _context.Contents.FirstOrDefaultAsync(e => e.Id == id);
        if (model == null) return false;
        _context.Contents.Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<List<Content>> GetListAsync() => await _context.Contents.ToListAsync();

    public async Task<Content?> GetModelAsync(long id) => await _context.Contents.FirstOrDefaultAsync(e => e.Id == id);

    public async Task InsertAsync(Content model)
    {
        await _context.Contents.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsEntityExistsAsync(long id) => await _context.Contents.AnyAsync(e => e.Id == id);

    public async Task<bool> UpdateAsync(Content model)
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
