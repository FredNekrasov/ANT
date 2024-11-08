using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;
using Microsoft.AspNetCore.Mvc;

namespace ANTWebAPI.PL.Controllers.impls;

/*
 * ArticleController is implementation of abstract class AbsController for ArticleDTO
 */
[Route("api/v1/[controller]")]
[ApiController]
public class ArticleController(ArticleUseCases articleUseCase) : AbsController<ArticleDTO>
{
    private readonly ArticleUseCases _articleUseCase = articleUseCase;
    /*
     * DeleteRecordAsync method deletes record from database by id
     * 
     * @param long id - id of record that should be deleted
     * 
     * if record is not found, NotFound()/404 is returned
     * if record is deleted successfully, Ok()/200 is returned 
     * if record is used as a foreign key in other entity records, BadRequest()/400 is returned
     */
    [HttpDelete("{id}")]
    public override async Task<IActionResult> DeleteRecordAsync(long id) => await _articleUseCase.DeleteAsync(id) switch
    {
        false => BadRequest("this record is used as a foreign key in other entity records"),
        null => NotFound(),
        true => Ok()
    };
    /*
     * GetListAsync method returns all records from database
     * 
     * if records are not found, NoContent()/204 is returned else Ok()/200 is returned
     */
    [HttpGet]
    public override async Task<ActionResult<ICollection<ArticleDTO>>> GetListAsync()
    {
        var models = await _articleUseCase.GetListAsync();
        var dtoList = models.Select(it => it.ToDto()).ToList();
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
    public override async Task<ActionResult<ArticleDTO>> GetRecordAsync(long id)
    {
        var model = await _articleUseCase.GetAsync(id);
        return model == null ? NotFound() : Ok(model.ToDto());
    }
    /*
     * PostRecordAsync method inserts record into database
     * 
     * @param ArticleDTO dto - record that should be inserted
     * 
     * if record is inserted successfully, Ok()/200 is returned else BadRequest()/400 is returned
     */
    [HttpPost]
    public override async Task<IActionResult> PostRecordAsync(ArticleDTO dto) => await _articleUseCase.InsertAsync(dto.ToModel()) ? Ok() : BadRequest();
    /*
     * PutRecordAsync method updates record in database
     * 
     * @param long id - id of record that should be updated
     * @param ArticleDTO dto - updated record
     * 
     * if record is updated successfully, NoContent()/204 is returned
     * if record is not found, NotFound()/404 is returned else BadRequest()/400 is returned
     */
    [HttpPut("{id}")]
    public override async Task<IActionResult> PutRecordAsync(long id, ArticleDTO dto) => await _articleUseCase.UpdateAsync(id, dto.ToModel()) switch
    {
        false => BadRequest(),
        null => NotFound(),
        true => NoContent(),
    };
}
