using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;
using Microsoft.AspNetCore.Mvc;

namespace ANTWebAPI.PL.Controllers.impls;

[Route("api/v1/[controller]")]
[ApiController]
public class CatalogController(CatalogUseCases catalogUseCase) : AbsController<CatalogDTO>
{
    
    [HttpDelete("{id:long}")]
    public override async Task<IActionResult> DeleteRecordAsync(long id) => await catalogUseCase.DeleteAsync(id) switch
    {
        false => BadRequest("this record is used as a foreign key in other entity record(s)"),
        null => NotFound(),
        true => Ok()
    };
    
    [HttpGet]
    public override async Task<ActionResult<ICollection<CatalogDTO>>> GetListAsync()
    {
        var models = await catalogUseCase.GetListAsync();
        if (models is []) return NoContent();
        List<CatalogDTO> dtoList = [];
        dtoList.AddRange(models.Select(t => t.ToDto()));
        return Ok(dtoList);
    }
    
    [HttpGet("{id:long}")]
    public override async Task<ActionResult<CatalogDTO>> GetRecordAsync(long id)
    {
        var model = await catalogUseCase.GetRecordAsync(id);
        return model == null ? NotFound() : Ok(model.ToDto());
    }
    
    [HttpPost]
    public override async Task<IActionResult> PostRecordAsync(CatalogDTO dto) => await catalogUseCase.InsertAsync(dto.ToModel()) ? Ok() : BadRequest();
    
    [HttpPut("{id:long}")]
    public override async Task<IActionResult> PutRecordAsync(long id, CatalogDTO dto) => await catalogUseCase.UpdateAsync(id, dto.ToModel()) switch
    {
        false => BadRequest(),
        null => NotFound(),
        true => Ok(),
    };
}
