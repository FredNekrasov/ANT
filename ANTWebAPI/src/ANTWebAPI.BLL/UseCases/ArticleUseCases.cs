using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.BLL.Utils;

namespace ANTWebAPI.BLL.UseCases;

public class ArticleUseCases(IRepository<Article> articleRepository)
{

    /**
     * DeleteAsync is a method for deleting Article entity
     *
     * @param long id - id of Article entity
     *
     * @return bool? - true if Article entity was deleted, false if Article entity was not deleted, null if Article entity was not found
    **/
    public async Task<bool?> DeleteAsync(long id)
    {
        if (!await articleRepository.IsEntityExistsAsync(id)) return null;
        return await articleRepository.DeleteAsync(id);
    }

    public async Task<List<Article>> GetListAsync() => await articleRepository.GetListAsync();
    
    public async Task<Article?> GetRecordAsync(long id) => await articleRepository.GetModelAsync(id);
    
    public async Task<bool> InsertAsync(Article? entity)
    {
        if (entity == null || !entity.IsDataValid() || await articleRepository.IsEntityExistsAsync(entity.Id)) return false;
        await articleRepository.InsertAsync(entity);
        return true;
    }
    
    /**
     * UpdateAsync is a method for updating Article entity
     *
     * @param long id - id of Article entity
     * @param Article? entity - Article entity
     *
     * @return bool? - true if Article entity was updated, false if Article entity was not updated, null if Article entity was not found 
    **/
    public async Task<bool?> UpdateAsync(long id, Article? entity)
    {
        if (entity == null || entity.Id != id || !entity.IsDataValid()) return false;
        if (!await articleRepository.IsEntityExistsAsync(id)) return null;
        return await articleRepository.UpdateAsync(entity);
    }
}
