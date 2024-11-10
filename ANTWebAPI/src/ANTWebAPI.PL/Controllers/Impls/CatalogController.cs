using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;
using Microsoft.AspNetCore.Mvc;

namespace ANTWebAPI.PL.Controllers.impls;

/*
 * CatalogController is implementation of abstract class AbsController for CatalogDTO
 */
[Route("api/v1/[controller]")]
[ApiController]
public class CatalogController(CatalogUseCases catalogUseCase) : AbsController<CatalogDTO>
{
    private readonly CatalogUseCases _catalogUseCase = catalogUseCase;
    /*
     * DeleteRecordAsync method deletes record from database by id
     * 
     * @param long id
     * 
     * if record is not found, NotFound()/404 is returned
     * if record is deleted successfully, Ok()/200 is returned
     * if record is used as a foreign key in other entities, BadRequest()/400 is returned
     */
    [HttpDelete("{id}")]
    public override async Task<IActionResult> DeleteRecordAsync(long id) => await _catalogUseCase.DeleteAsync(id) switch
    {
        false => BadRequest("this record is used as a foreign key in other entities"),
        null => NotFound(),
        true => Ok()
    };
    /*
     * GetListAsync method returns all records from database
     * 
     * if records are not found, NoContent()/204 is returned else Ok()/200 is returned
     */
    [HttpGet]
    public override async Task<ActionResult<ICollection<CatalogDTO>>> GetListAsync()
    {
        var models = await _catalogUseCase.GetListAsync();
        List<CatalogDTO> dtoList = [];
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
    public override async Task<ActionResult<CatalogDTO>> GetRecordAsync(long id)
    {
        var model = await _catalogUseCase.GetAsync(id);
        return model == null ? NotFound() : Ok(model.ToDto());
    }
    /*
     * PostRecordAsync method inserts record into database
     * 
     * @param CatalogDTO dto - record that should be inserted
     * 
     * if record is inserted successfully, Ok()/200 is returned else BadRequest()/400 is returned
     */
    [HttpPost]
    public override async Task<IActionResult> PostRecordAsync(CatalogDTO dto) => await _catalogUseCase.InsertAsync(dto.ToModel()) ? Ok() : BadRequest();
    /*
     * PutRecordAsync method updates record in database
     * 
     * @param long id - id of record that should be updated
     * @param CatalogDTO dto - updated record
     * 
     * if record is updated successfully, NoContent()/204 is returned
     * if record is not found, NotFound()/404 is returned else BadRequest()/400 is returned
     */
    [HttpPut("{id}")]
    public override async Task<IActionResult> PutRecordAsync(long id, CatalogDTO dto) => await _catalogUseCase.UpdateAsync(id, dto.ToModel()) switch
    {
        false => BadRequest(),
        null => NotFound(),
        true => NoContent(),
    };
}
