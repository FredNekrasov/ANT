using ANTWebAPI.BLL.Models;

namespace ANTWebAPI.BLL.Repositories;

public interface IChapterRepository
{
    Task<List<Chapter>> GetListAsync();
}
