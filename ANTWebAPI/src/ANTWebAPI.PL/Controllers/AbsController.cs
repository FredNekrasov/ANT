using Microsoft.AspNetCore.Mvc;

namespace ANTWebAPI.PL.Controllers;

public abstract class AbsController<D> : ControllerBase
{
    /**
     * GetListAsync method returns all records from database
     *
     * if records are not found, NoContent()/204 is returned else Ok()/200 is returned
    **/
    public abstract Task<ActionResult<ICollection<D>>> GetListAsync();
    public abstract Task<IActionResult> PutRecordAsync(long id, D dto);
    /**
     * PostRecordAsync method inserts record into database
     *
     * @param D dto is the record that should be inserted
     *
     * if record is inserted successfully, Ok()/200 is returned else BadRequest()/400 is returned
    **/
    public abstract Task<IActionResult> PostRecordAsync(D dto);
    /**
     * DeleteRecordAsync method deletes record from database by id
     *
     * @param long id - id of the record that should be deleted
     *
     * if record is not found, NotFound()/404 is returned
     * if record is deleted successfully, Ok()/200 is returned
     * if record is used as a foreign key in other entity records, BadRequest()/400 is returned
    **/
    public abstract Task<IActionResult> DeleteRecordAsync(long id);
    /**
     * GetRecordAsync method returns record from database by id
     *
     * @param long id - id of the record that should be returned
     *
     * if record is not found, NotFound()/404 is returned else Ok()/200 is returned
    **/
    public abstract Task<ActionResult<D>> GetRecordAsync(long id);
}
