using ANTWebAPI.BLL.Models;

namespace ANTWebAPI.BLL.Repositories;

/*
 * IChapterRepository is a chapter repository interface that provides methods to get data about chapters
 */
public interface IChapterRepository
{
    /*
     * GetListAsync - get list of all chapters from database
     * return list of all chapters
     */
    Task<List<Chapter>> GetListAsync();
    /*
     * GetPagedListByCatalogAsync - get list of chapters by catalog id from database with pagination
     * catalogId - id of catalog
     * pageNumber - number of page
     * pageSize - size of page/number of chapters
     * return list of chapters by catalog id with pagination parameters
     */
    Task<List<Chapter>> GetPagedListByCatalogAsync(int catalogId, int pageNumber, int pageSize);
    /*
     * GetTotalCountAsync - get total count of chapters from database
     * return total count of chapters
     */
    Task<int> GetTotalCountAsync();
}
