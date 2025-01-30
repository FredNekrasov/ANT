using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;
using Microsoft.AspNetCore.Mvc;

namespace ANTWebAPI.PL.Controllers.impls;

[Route("api/v1/[controller]")]
[ApiController]
public class ContentController(ContentUseCases contentUseCase) : AbsController<ContentDTO>
{
    
    [HttpDelete("{id:long}")]
    public override async Task<IActionResult> DeleteRecordAsync(long id) => await contentUseCase.DeleteAsync(id) ? Ok() : NotFound();
    
    [HttpGet]
    public override async Task<ActionResult<ICollection<ContentDTO>>> GetListAsync()
    {
        var models = await contentUseCase.GetListAsync();
        if (models is []) return NoContent();
        List<ContentDTO> dtoList = [];
        dtoList.AddRange(models.Select(t => t.ToDto()));
        return Ok(dtoList);
    }
    
    [HttpGet("{id:long}")]
    public override async Task<ActionResult<ContentDTO>> GetRecordAsync(long id)
    {
        var model = await contentUseCase.GetRecordAsync(id);
        return model == null ? NotFound() : Ok(model.ToDto());
    }
    
    [HttpPost]
    public override async Task<IActionResult> PostRecordAsync(ContentDTO dto) => await contentUseCase.InsertAsync(dto.ToModel()) ? Ok() : BadRequest();
    
    [HttpPut("{id:long}")]
    public override async Task<IActionResult> PutRecordAsync(long id, ContentDTO dto) => await contentUseCase.UpdateAsync(id, dto.ToModel()) switch
    {
        false => BadRequest(),
        null => NotFound(),
        true => Ok(),
    };
}
