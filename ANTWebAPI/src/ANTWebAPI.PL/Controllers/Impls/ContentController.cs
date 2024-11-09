using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;
using Microsoft.AspNetCore.Mvc;

namespace ANTWebAPI.PL.Controllers.impls;

/*
 * ContentController is implementation of abstract class AbsController for ContentDTO
 */
[Route("api/v1/[controller]")]
[ApiController]
public class ContentController(ContentUseCases contentUseCase) : AbsController<ContentDTO>
{
    private readonly ContentUseCases _contentUseCase = contentUseCase;
    /*
     * DeleteRecordAsync method deletes record from database by id
     * 
     * @param long id - id of record that should be deleted
     * 
     * if record is not found, NotFound()/404 is returned else Ok()/200 is returned
     */
    [HttpDelete("{id}")]
    public override async Task<IActionResult> DeleteRecordAsync(long id) => await _contentUseCase.DeleteAsync(id) == true ? Ok() : NotFound();
    /*
     * GetListAsync method returns all records from database
     * 
     * if records are not found, NoContent()/204 is returned else Ok()/200 is returned
     */
    [HttpGet]
    public override async Task<ActionResult<ICollection<ContentDTO>>> GetListAsync()
    {
        var models = await _contentUseCase.GetListAsync();
        List<ContentDTO> dtoList = [];
        for (int i = 0; i < models.Count; i++)
        {
            dtoList.Add(models[i].ToDto());
        }
        return ((dtoList == null) || (dtoList.Count == 0)) ? NoContent() : Ok(dtoList);
    }
    /*
     * GetRecordAsync method returns record from database by id
     * 
     * @param long id - id of record that should be returned
     * 
     * if record is not found, NotFound()/404 is returned else Ok()/200 is returned
     */
    [HttpGet("{id}")]
    public override async Task<ActionResult<ContentDTO>> GetRecordAsync(long id)
    {
        var model = await _contentUseCase.GetAsync(id);
        return model == null ? NotFound() : Ok(model.ToDto());
    }
    /*
     * PostRecordAsync method inserts record into database
     * 
     * @param ContentDTO dto - record that should be inserted
     * 
     * if record is inserted successfully, Ok()/200 is returned else BadRequest()/400 is returned
     */
    [HttpPost]
    public override async Task<IActionResult> PostRecordAsync(ContentDTO dto) => await _contentUseCase.InsertAsync(dto.ToModel()) ? Ok() : BadRequest();
    /*
     * PutRecordAsync method updates record in database
     * 
     * @param long id - id of record that should be updated
     * @param ContentDTO dto - updated record
     * 
     * if record is updated successfully, NoContent()/204 is returned
     * if record is not found, NotFound()/404 is returned else BadRequest()/400 is returned
     */
    [HttpPut("{id}")]
    public override async Task<IActionResult> PutRecordAsync(long id, ContentDTO dto) => await _contentUseCase.UpdateAsync(id, dto.ToModel()) switch
    {
        false => BadRequest(),
        null => NotFound(),
        true => NoContent(),
    };
}
