using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Repositories;

/*
 * Catalog Repository is used for Catalog CRUD operations and other
 */
public class CatalogRepository(ANTDbContext context) : IRepository<Catalog>
{
    private readonly ANTDbContext _context = context;
    /*
     * Delete Catalog method is used for deleting Catalog
     * 
     * @param id - Catalog id
     * 
     * @return bool - true if deleted else false
     */
    public async Task<bool> DeleteAsync(long id)
    {
        if (await _context.Articles.AnyAsync(e => e.CatalogId == id)) return false;
        var model = await _context.Catalogs.FirstOrDefaultAsync(e => e.Id == id);
        if (model == null) return false;
        _context.Catalogs.Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }
    /*
     * Get Catalog List method is used for getting Catalog List
     * 
     * @return List<Catalog> - Catalog List
     */
    public async Task<List<Catalog>> GetListAsync() => await _context.Catalogs.ToListAsync();
    /*
     * Get Catalog method is used for getting Catalog
     * 
     * @param id - Catalog id
     * 
     * @return Catalog - Catalog
     */
    public async Task<Catalog?> GetModelAsync(long id) => await _context.Catalogs.FirstOrDefaultAsync(e => e.Id == id);
    /*
     * Insert Catalog method is used for inserting Catalog
     * 
     * @param model - Catalog
     * 
     * @returns nothing
     */
    public async Task InsertAsync(Catalog model)
    {
        await _context.Catalogs.AddAsync(model);
        await _context.SaveChangesAsync();
    }
    /*
     * IsEntityExists method is used for checking if entity exists
     * 
     * @param id - Catalog id
     * 
     * @returns bool - true if exists else false
     */
    public async Task<bool> IsEntityExistsAsync(long id) => await _context.Catalogs.AnyAsync(e => e.Id == id);
    /*
     * Update Catalog method is used for updating Catalog
     * 
     * @param model - Catalog
     * 
     * @returns bool - true if updated else false
     */
    public async Task<bool> UpdateAsync(Catalog model)
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
