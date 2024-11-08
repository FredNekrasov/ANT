using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.BLL.Utils;

namespace ANTWebAPI.BLL.UseCases;

/*
 * ContentUseCases is a collection of business logic methods for Content model
 */
public class ContentUseCases(IRepository<Content> repository)
{
    private readonly IRepository<Content> _repository = repository;
    /*
     * DeleteAsync is a method for deleting Content entity
     * 
     * @param long id - id of Content entity
     * 
     * @return bool - true if Content entity was deleted, false if Content entity was not deleted
     */
    public async Task<bool?> DeleteAsync(long id) => await _repository.DeleteAsync(id);
    /*
     * GetListAsync is a method for getting list of Content entities
     * 
     * @return List<Content> - list of Content entities
     */
    public async Task<List<Content>> GetListAsync() => await _repository.GetListAsync();
    /*
     * GetAsync is a method for getting Content entity
     * 
     * @param long id - id of Content entity
     * 
     * @return Content? - Content entity if it was found, null otherwise
     */
    public async Task<Content?> GetAsync(long id) => await _repository.GetModelAsync(id);
    /*
     * InsertAsync is a method for inserting Content entity
     * 
     * @param Content? entity - Content entity
     * 
     * @return bool - true if Content entity was inserted, false otherwise
     */
    public async Task<bool> InsertAsync(Content? entity)
    {
        if (entity == null || !entity.IsDataValid() || await _repository.IsEntityExistsAsync(entity.Id)) return false;
        await _repository.InsertAsync(entity);
        return true;
    }
    /*
     * UpdateAsync is a method for updating Content entity
     * 
     * @param long id - id of Content entity
     * @param Content? entity - Content entity
     * 
     * @return bool? - true if Content entity was updated, false if Content entity was not updated, null otherwise
     */
    public async Task<bool?> UpdateAsync(long id, Content? entity)
    {
        if (entity == null || entity.Id != id || !entity.IsDataValid()) return false;
        if (!await _repository.IsEntityExistsAsync(id)) return null;
        return await _repository.UpdateAsync(entity);
    }
}
