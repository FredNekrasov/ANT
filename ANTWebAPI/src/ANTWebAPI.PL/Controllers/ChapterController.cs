using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;
using Microsoft.AspNetCore.Mvc;

namespace ANTWebAPI.PL.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ChapterController(IChapterRepository chapterRepository) : ControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult<ICollection<ChapterDTO>>> GetListAsync()
    {
        var models = await chapterRepository.GetListAsync();
        if (models is []) return NoContent();
        List<ChapterDTO> dtoList = [];
        dtoList.AddRange(models.Select(t => t.ToDto()));
        return Ok(dtoList);
    }
    
    /*
     * GetPagedListAsync method returns page of records from database
     * 
     * @catalogId - id of catalog that should be used for filtering. [default value = 1]
     * @pageNumber - number of page that should be returned. [default value = 1]
     * @pageSize - size of page that should be returned. [default value = 50]
     *
     * if there are no records in database, then NoContent/204 status code is returned
     * otherwise, Ok/200 status code and PagedResponse<ChapterDTO> is returned
     * 
     * @returns PagedResponse<ChapterDTO>
     */
    [HttpGet("{catalogId:long}")]
    public async Task<ActionResult<PagedResponse<ChapterDTO>>> GetPagedListAsync(long catalogId = 1, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
    {
        var models = await chapterRepository.GetPagedListByCatalogAsync(catalogId, pageNumber, pageSize);
        if (models is []) return NoContent();
        List<ChapterDTO> dtoList = [];
        dtoList.AddRange(models.Select(t => t.ToDto()));
        var totalRecords = await chapterRepository.GetTotalCountAsync();
        var response = new PagedResponse<ChapterDTO>(pageNumber, dtoList.Count, totalRecords, dtoList);
        return Ok(response);
    }
}
