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
}
