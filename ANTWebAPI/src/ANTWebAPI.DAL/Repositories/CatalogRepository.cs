﻿using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ANTWebAPI.DAL.Repositories;

internal class CatalogRepository(ANTDbContext context) : IRepository<Catalog>
{
    private readonly ANTDbContext _context = context;

    public async Task<bool> DeleteAsync(long id)
    {
        if (await _context.Articles.AnyAsync(e => e.CatalogId == id)) return false;
        var model = await _context.Catalogs.FirstAsync(e => e.Id == id);
        _context.Catalogs.Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Catalog>> GetListAsync() => await _context.Catalogs.ToListAsync();

    public async Task<Catalog?> GetModelAsync(long id) => await _context.Catalogs.FirstOrDefaultAsync(e => e.Id == id);

    public async Task InsertAsync(Catalog model)
    {
        await _context.Catalogs.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsEntityExistsAsync(long id) => await _context.Catalogs.AnyAsync(e => e.Id == id);

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