using ANTWebAPI.BLL.Models;

namespace ANTWebAPI.BLL.Repositories;

public interface IChapterRepository
{
    Task<List<Chapter>> GetListAsync();
    Task<List<Chapter>> GetPagedListByCatalogAsync(int catalogId, int pageNumber, int pageSize);
    Task<int> GetTotalCountAsync();
}
