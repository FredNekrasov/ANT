using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;
using Microsoft.AspNetCore.Mvc;

namespace ANTWebAPI.PL.Controllers;

/*
 * ChapterController is used for getting list of chapters
 */
[Route("api/v1/[controller]")]
[ApiController]
public class ChapterController(IChapterRepository repository) : ControllerBase
{
    private readonly IChapterRepository _repository = repository;
    /*
     * GetListAsync method returns all records from database
     */
    [HttpGet]
    public async Task<ActionResult<ICollection<ChapterDTO>>> GetListAsync()
    {
        var models = await _repository.GetListAsync();
        List<ChapterDTO> dtoList = [];
        for (int i = 0; i < models.Count; i++)
        {
            dtoList.Add(models[i].ToDto());
        }
        return Ok(dtoList);
    }
    /*
     * GetPagedListAsync method returns page of records from database
     * 
     * @catalogId - id of catalog that should be used for filtering
     * @pageNumber - number of page that should be returned
     * @pageSize - size of page that should be returned
     * 
     * @returns PagedResponse<ChapterDTO>
     */
    [HttpGet("{catalogId}")]
    public async Task<ActionResult<PagedResponse<ChapterDTO>>> GetPagedListAsync(int catalogId = 1, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25)
    {
        var models = await _repository.GetPagedListByCatalogAsync(catalogId, pageNumber, pageSize);
        List<ChapterDTO> dtoList = [];
        for (int i = 0; i < models.Count; i++)
        {
            dtoList.Add(models[i].ToDto());
        }
        var totalRecords = await _repository.GetTotalCountAsync();
        var response = new PagedResponse<ChapterDTO>(pageNumber, pageSize, totalRecords, dtoList);
        return Ok(response);
    }
}
