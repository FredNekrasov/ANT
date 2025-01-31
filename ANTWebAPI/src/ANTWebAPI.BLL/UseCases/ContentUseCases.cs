using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.BLL.Utils;

namespace ANTWebAPI.BLL.UseCases;

public class ContentUseCases(IRepository<Content> contentRepository)
{
    public async Task<bool> DeleteAsync(long id) => await contentRepository.DeleteAsync(id);

    public async Task<List<Content>> GetListAsync() => await contentRepository.GetListAsync();
    
    public async Task<Content?> GetRecordAsync(long id) => await contentRepository.GetModelAsync(id);
    
    public async Task<bool> InsertAsync(Content? entity)
    {
        if (entity == null || !entity.IsDataValid() || await contentRepository.IsEntityExistsAsync(entity.Id)) return false;
        await contentRepository.InsertAsync(entity);
        return true;
    }

    /**
     * UpdateAsync is a method for updating Content entity
     * 
     * @param long id - id of Content entity
     * @param Content? entity - Content entity to update
     * 
     * @return bool? - true if Content entity was updated, false if Content entity was not updated, null if Content entity was not found
    **/
    public async Task<bool?> UpdateAsync(long id, Content? entity)
    {
        if (entity == null || entity.Id != id || !entity.IsDataValid()) return false;
        if (!await contentRepository.IsEntityExistsAsync(id)) return null;
        return await contentRepository.UpdateAsync(entity);
    }
}
