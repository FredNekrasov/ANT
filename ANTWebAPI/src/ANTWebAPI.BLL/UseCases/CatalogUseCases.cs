using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.BLL.Utils;

namespace ANTWebAPI.BLL.UseCases;

public class CatalogUseCases(IRepository<Catalog> catalogRepository)
{
    
    /**
     * DeleteAsync is a method for deleting Catalog entity
     *
     * @param long id - id of Catalog entity
     *
     * @return bool? - true if Catalog entity was deleted, false if Catalog entity was not deleted, null if Catalog entity was not found
    **/
    public async Task<bool?> DeleteAsync(long id)
    {
        if (!await catalogRepository.IsEntityExistsAsync(id)) return null;
        return await catalogRepository.DeleteAsync(id);
    }

    public async Task<List<Catalog>> GetListAsync() => await catalogRepository.GetListAsync();
    
    public async Task<Catalog?> GetRecordAsync(long id) => await catalogRepository.GetModelAsync(id);
    
    public async Task<bool> InsertAsync(Catalog? entity)
    {
        if (entity == null || !entity.IsDataValid() || await catalogRepository.IsEntityExistsAsync(entity.Id)) return false;
        await catalogRepository.InsertAsync(entity);
        return true;
    }
    
    /**
     * UpdateAsync is a method for updating Catalog entity
     * 
     * @param long id - id of Catalog entity
     * @param Catalog? entity - Catalog entity
     * 
     * @return bool? - true if Catalog entity was updated, null if Catalog entity was not found, false if Catalog entity was not updated
    **/
    public async Task<bool?> UpdateAsync(long id, Catalog? entity)
    {
        if (entity == null || entity.Id != id || !entity.IsDataValid()) return false;
        if (!await catalogRepository.IsEntityExistsAsync(id)) return null;
        return await catalogRepository.UpdateAsync(entity);
    }
}
