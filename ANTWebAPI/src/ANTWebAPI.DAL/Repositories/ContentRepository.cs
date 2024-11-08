using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Repositories;

/*
 * ContentRepository is used for Content CRUD operations and other
 */
public class ContentRepository(ANTDbContext context) : IRepository<Content>
{
    private readonly ANTDbContext _context = context;
    /*
     * DeleteAsync method is used for deleting Content by id
     * 
     * @param id - Content id
     * 
     * @return bool - true if deleted else false
     */
    public async Task<bool> DeleteAsync(long id)
    {
        var model = await _context.Contents.FirstOrDefaultAsync(e => e.Id == id);
        if (model == null) return false;
        _context.Contents.Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }
    /*
     * GetListAsync method is used for getting Content List
     * 
     * @return List<Content> - Content List
     */
    public async Task<List<Content>> GetListAsync() => await _context.Contents.ToListAsync();
    /*
     * GetModelAsync method is used for getting Content by id
     * 
     * @param id - Content id
     * 
     * @return Content? - Content if record with given id exists else null
     */
    public async Task<Content?> GetModelAsync(long id) => await _context.Contents.FirstOrDefaultAsync(e => e.Id == id);
    /*
     * InsertAsync method is used for inserting Content
     * 
     * @param model - Content
     * 
     * @returns nothing
     */
    public async Task InsertAsync(Content model)
    {
        await _context.Contents.AddAsync(model);
        await _context.SaveChangesAsync();
    }
    /*
     * IsEntityExists method is used for checking if entity exists
     * 
     * @param id - Content id
     * 
     * @return bool - true if exists else false
     */
    public async Task<bool> IsEntityExistsAsync(long id) => await _context.Contents.AnyAsync(e => e.Id == id);
    /*
     * UpdateAsync method is used for updating Content
     * 
     * @param model - Content
     * 
     * @returns bool - true if updated else false
     */
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
