using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.BLL.Utils;

namespace ANTWebAPI.BLL.UseCases;

/*
 * ArticleUseCases is a collection of business logic methods for Article model
 */
public class ArticleUseCases(IRepository<Article> repository)
{
    private readonly IRepository<Article> _repository = repository;
    /*
     * DeleteAsync is a method for deleting Article entity
     * 
     * @param long id - id of Article entity
     * 
     * @return bool? - true if Article entity was deleted, false if Article entity was not deleted, null if Article entity was not found
     */
    public async Task<bool?> DeleteAsync(long id)
    {
        if (!await _repository.IsEntityExistsAsync(id)) return null;
        return await _repository.DeleteAsync(id);
    }
    /*
     * GetListAsync is a method for getting list of Article entities
     * 
     * @return List<Article> - list of Article entities
     */
    public async Task<List<Article>> GetListAsync() => await _repository.GetListAsync();
    /*
     * GetAsync is a method for getting Article entity
     * 
     * @param long id - id of Article entity
     * 
     * @return Article? - Article entity if it was found, null otherwise
     */
    public async Task<Article?> GetAsync(long id) => await _repository.GetModelAsync(id);
    /*
     * InsertAsync is a method for inserting Article entity
     * 
     * @param Article? entity - Article entity
     * 
     * @return bool - true if Article entity was inserted, false otherwise
     */
    public async Task<bool> InsertAsync(Article? entity)
    {
        if (entity == null || !entity.IsDataValid() || await _repository.IsEntityExistsAsync(entity.Id)) return false;
        await _repository.InsertAsync(entity);
        return true;
    }
    /*
     * UpdateAsync is a method for updating Article entity
     * 
     * @param long id - id of Article entity
     * @param Article? entity - Article entity
     * 
     * @return bool? - true if Article entity was updated, false if Article entity was not updated, null otherwise
     */
    public async Task<bool?> UpdateAsync(long id, Article entity)
    {
        if (entity == null || entity.Id != id || !entity.IsDataValid()) return false;
        if (!await _repository.IsEntityExistsAsync(id)) return null;
        return await _repository.UpdateAsync(entity);
    }
}
