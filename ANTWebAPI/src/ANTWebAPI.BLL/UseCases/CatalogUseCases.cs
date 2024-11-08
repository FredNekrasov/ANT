using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.BLL.Utils;

namespace ANTWebAPI.BLL.UseCases;

/*
 * CatalogUseCases is a collection of business logic methods for Catalog model
 */
public class CatalogUseCases(IRepository<Catalog> repository)
{
    private readonly IRepository<Catalog> _repository = repository;
    /*
     * DeleteAsync is a method for deleting Catalog entity
     * 
     * @param long id - id of Catalog entity
     * 
     * @return bool? - true if Catalog entity was deleted, false if Catalog entity was not deleted, null if Catalog entity was not found
     */
    public async Task<bool?> DeleteAsync(long id)
    {
        if (!await _repository.IsEntityExistsAsync(id)) return null;
        return await _repository.DeleteAsync(id);
    }
    /*
     * GetListAsync is a method for getting list of Catalog entities
     * 
     * @return List<Catalog> - list of Catalog entities
     */
    public async Task<List<Catalog>> GetListAsync() => await _repository.GetListAsync();
    /*
     * GetAsync is a method for getting Catalog entity
     * 
     * @param long id - id of Catalog entity
     * 
     * @return Catalog? - Catalog entity if it was found, null otherwise
     */
    public async Task<Catalog?> GetAsync(long id) => await _repository.GetModelAsync(id);
    /*
     * InsertAsync is a method for inserting Catalog entity
     * 
     * @param Catalog? entity - Catalog entity
     * 
     * @return bool - true if Catalog entity was inserted, false otherwise
     */
    public async Task<bool> InsertAsync(Catalog? entity)
    {
        if (entity == null || !entity.IsDataValid() || await _repository.IsEntityExistsAsync(entity.Id)) return false;
        await _repository.InsertAsync(entity);
        return true;
    }
    /*
     * UpdateAsync is a method for updating Catalog entity
     * 
     * @param long id - id of Catalog entity
     * @param Catalog? entity - Catalog entity
     * 
     * @return bool? - true if Catalog entity was updated, null if Catalog entity was not found, false otherwise
     */
    public async Task<bool?> UpdateAsync(long id, Catalog entity)
    {
        if (entity == null || entity.Id != id || !entity.IsDataValid()) return false;
        if (!await _repository.IsEntityExistsAsync(id)) return null;
        return await _repository.UpdateAsync(entity);
    }
}
