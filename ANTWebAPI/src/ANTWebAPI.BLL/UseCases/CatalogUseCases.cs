using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;

namespace ANTWebAPI.BLL.UseCases;

public class CatalogUseCases(IRepository<Catalog> repository)
{
    private readonly IRepository<Catalog> _repository = repository;

    public async Task<bool?> DeleteAsync(long id)
    {
        if (!await _repository.IsEntityExistsAsync(id)) return null;
        return await _repository.DeleteAsync(id);
    }

    public async Task<List<Catalog>> GetListAsync() => await _repository.GetListAsync();

    public async Task<Catalog?> GetAsync(long id) => await _repository.GetModelAsync(id);

    public async Task<bool> InsertAsync(Catalog? entity)
    {
        if (entity == null || !entity.IsDataValid() || await _repository.IsEntityExistsAsync(entity.Id)) return false;
        await _repository.InsertAsync(entity);
        return true;
    }

    public async Task<bool?> UpdateAsync(long id, Catalog entity)
    {
        if (entity == null || entity.Id != id || !entity.IsDataValid()) return false;
        if (!await _repository.IsEntityExistsAsync(id)) return null;
        return await _repository.UpdateAsync(entity);
    }
}
