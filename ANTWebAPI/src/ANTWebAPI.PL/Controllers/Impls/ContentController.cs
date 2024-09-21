using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ANTWebAPI.PL.Controllers.impls;

[Route("api/v1/[controller]")]
[ApiController]
public class ContentController(ContentUseCases contentUseCase) : AbsController<ContentDTO>
{
    private readonly ContentUseCases _contentUseCase = contentUseCase;

    [HttpDelete("{id}")]
    public override async Task<IActionResult> DeleteRecordAsync(long id) => await _contentUseCase.DeleteAsync(id) == true ? Ok() : NotFound();

    [HttpGet]
    public override async Task<ActionResult<ICollection<ContentDTO>>> GetListAsync()
    {
        var models = await _contentUseCase.GetListAsync();
        return models.IsNullOrEmpty() ? NoContent() : Ok(models.Select(it => it.ToDto()));
    }

    [HttpGet("{id}")]
    public override async Task<ActionResult<ContentDTO>> GetRecordAsync(long id)
    {
        var model = await _contentUseCase.GetAsync(id);
        return model == null ? NotFound() : Ok(model.ToDto());
    }

    [HttpPost]
    public override async Task<IActionResult> PostRecordAsync(ContentDTO dto) => await _contentUseCase.InsertAsync(dto.ToModel()) ? Ok() : BadRequest();

    [HttpPut("{id}")]
    public override async Task<IActionResult> PutRecordAsync(long id, ContentDTO dto) => await _contentUseCase.UpdateAsync(id, dto.ToModel()) switch
    {
        false => BadRequest(),
        null => NotFound(),
        true => NoContent(),
    };
}
