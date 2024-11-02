using ANTWebAPI.BLL.Models;

namespace ANTWebAPI.BLL.Repositories;

public interface IChapterRepository
{
    Task<List<Chapter>> GetListAsync();
    Task<List<Chapter>> GetPagedListAsync(int pageNumber, int pageSize);
    Task<int> GetTotalCountAsync();
}
