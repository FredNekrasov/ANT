using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ANTWebAPI.PL.Controllers.impls;

[Route("api/v1/[controller]")]
[ApiController]
public class CatalogController(CatalogUseCases catalogUseCase) : AbsController<CatalogDTO>
{
    private readonly CatalogUseCases _catalogUseCase = catalogUseCase;

    [HttpDelete("{id}")]
    public override async Task<IActionResult> DeleteRecordAsync(long id) => await _catalogUseCase.DeleteAsync(id) switch
    {
        false => BadRequest("this record is used as a foreign key in other entities"),
        null => NotFound(),
        true => Ok()
    };

    [HttpGet]
    public override async Task<ActionResult<ICollection<CatalogDTO>>> GetListAsync()
    {
        var models = await _catalogUseCase.GetListAsync();
        return models.IsNullOrEmpty() ? NoContent() : Ok(models.Select(it => it.ToDto()));
    }

    [HttpGet("{id}")]
    public override async Task<ActionResult<CatalogDTO>> GetRecordAsync(long id)
    {
        var model = await _catalogUseCase.GetAsync(id);
        return model == null ? NotFound() : Ok(model.ToDto());
    }

    [HttpPost]
    public override async Task<IActionResult> PostRecordAsync(CatalogDTO dto) => await _catalogUseCase.InsertAsync(dto.ToModel()) ? Ok() : BadRequest();

    [HttpPut("{id}")]
    public override async Task<IActionResult> PutRecordAsync(long id, CatalogDTO dto) => await _catalogUseCase.UpdateAsync(id, dto.ToModel()) switch
    {
        false => BadRequest(),
        null => NotFound(),
        true => NoContent(),
    };
}
