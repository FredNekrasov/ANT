using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.BLL.Utils;

namespace ANTWebAPI.BLL.UseCases;

public class ContentUseCases(IRepository<Content> repository)
{
    private readonly IRepository<Content> _repository = repository;

    public async Task<bool?> DeleteAsync(long id) => await _repository.DeleteAsync(id);

    public async Task<List<Content>> GetListAsync() => await _repository.GetListAsync();

    public async Task<Content?> GetAsync(long id) => await _repository.GetModelAsync(id);

    public async Task<bool> InsertAsync(Content? entity)
    {
        if (entity == null || !entity.IsDataValid() || await _repository.IsEntityExistsAsync(entity.Id)) return false;
        await _repository.InsertAsync(entity);
        return true;
    }

    public async Task<bool?> UpdateAsync(long id, Content? entity)
    {
        if (entity == null || entity.Id != id || !entity.IsDataValid()) return false;
        if (!await _repository.IsEntityExistsAsync(id)) return null;
        return await _repository.UpdateAsync(entity);
    }
}
