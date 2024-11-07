using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;
using Microsoft.AspNetCore.Mvc;

namespace ANTWebAPI.PL.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ChapterController(IChapterRepository repository) : ControllerBase
{
    private readonly IChapterRepository _repository = repository;

    [HttpGet]
    public async Task<ActionResult<ICollection<ChapterDTO>>> GetListAsync()
    {
        var models = await _repository.GetListAsync();
        return Ok(models.Select(it => it.ToDto()));
    }
    [HttpGet("{catalogId}")]
    public async Task<ActionResult<PagedResponse<ChapterDTO>>> GetPagedListAsync(int catalogId = 1, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25)
    {
        var models = await _repository.GetPagedListByCatalogAsync(catalogId, pageNumber, pageSize);
        var dtoList = models.Select(it => it.ToDto()).ToList();
        var totalRecords = await _repository.GetTotalCountAsync();
        var response = new PagedResponse<ChapterDTO>(pageNumber, pageSize, totalRecords, dtoList);
        return Ok(response);
    }
}
