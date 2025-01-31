using ANTWebAPI.BLL.Models;

namespace ANTWebAPI.BLL.Repositories;

public interface IChapterRepository
{
    Task<List<Chapter>> GetListAsync();
    
    /**
     * GetPagedListByCatalogAsync - get list of chapters by catalog id from database with pagination
     * catalogId - id of  catalog
     * pageNumber - number of page
     * pageSize - size of page/number of chapters
     * return list of chapters by catalog id with pagination parameters
     */
    Task<List<Chapter>> GetPagedListByCatalogAsync(long catalogId, int pageNumber, int pageSize);
    
    /**
     * GetTotalCountAsync - get total count of chapters from database
     */
    Task<int> GetTotalCountAsync();
}
