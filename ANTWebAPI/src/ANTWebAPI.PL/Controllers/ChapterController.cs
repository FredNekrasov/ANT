using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        return models.IsNullOrEmpty() ? NoContent() : Ok(models.Select(it => it.ToDto()));
    }
    [HttpGet("{catalogId}")]
    public async Task<ActionResult<ICollection<ChapterDTO>>> GetListByCatalogAsync(int catalogId)
    {
        var models = await _repository.GetListByCatalogAsync(catalogId);
        return models.IsNullOrEmpty() ? NoContent() : Ok(models.Select(it => it.ToDto()));
    }
    [HttpGet("{pageNumber}&{pageSize}")]
    public async Task<ActionResult<PagedResponse<ChapterDTO>>> GetPagedListAsync(int pageNumber, int pageSize)
    {
        var models = await _repository.GetPagedListAsync(pageNumber, pageSize);
        var dtoList = models.Select(it => it.ToDto()).ToList();
        var totalRecords = await _repository.GetTotalCountAsync();
        var response = new PagedResponse<ChapterDTO>(pageNumber, pageSize, totalRecords, dtoList);
        return models.IsNullOrEmpty() ? NoContent() : Ok(response);
    }
}
