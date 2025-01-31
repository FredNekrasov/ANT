namespace ANTWebAPI.BLL.Repositories;

public interface IRepository<M>
{
    Task InsertAsync(M model);

    Task<bool> DeleteAsync(long id);
    
    Task<List<M>> GetListAsync();
    
    Task<M?> GetModelAsync(long id);
    
    Task<bool> UpdateAsync(M model);
    
    Task<bool> IsEntityExistsAsync(long id);
}
