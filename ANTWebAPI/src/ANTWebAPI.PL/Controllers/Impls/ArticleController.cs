using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;
using Microsoft.AspNetCore.Mvc;

namespace ANTWebAPI.PL.Controllers.impls;

[Route("api/v1/[controller]")]
[ApiController]
public class ArticleController(ArticleUseCases articleUseCase) : AbsController<ArticleDTO>
{
    private readonly ArticleUseCases _articleUseCase = articleUseCase;

    [HttpDelete("{id}")]
    public override async Task<IActionResult> DeleteRecordAsync(long id) => await _articleUseCase.DeleteAsync(id) switch
    {
        false => BadRequest("this record is used as a foreign key in other entity records"),
        null => NotFound(),
        true => Ok()
    };

    [HttpGet]
    public override async Task<ActionResult<ICollection<ArticleDTO>>> GetListAsync()
    {
        var models = await _articleUseCase.GetListAsync();
        var dtoList = models.Select(it => it.ToDto()).ToList();
        return ((dtoList == null) || (dtoList.Count == 0)) ? NoContent() : Ok(dtoList);
    }

    [HttpGet("{id}")]
    public override async Task<ActionResult<ArticleDTO>> GetRecordAsync(long id)
    {
        var model = await _articleUseCase.GetAsync(id);
        return model == null ? NotFound() : Ok(model.ToDto());
    }

    [HttpPost]
    public override async Task<IActionResult> PostRecordAsync(ArticleDTO dto) => await _articleUseCase.InsertAsync(dto.ToModel()) ? Ok() : BadRequest();

    [HttpPut("{id}")]
    public override async Task<IActionResult> PutRecordAsync(long id, ArticleDTO dto) => await _articleUseCase.UpdateAsync(id, dto.ToModel()) switch
    {
        false => BadRequest(),
        null => NotFound(),
        true => NoContent(),
    };
}
