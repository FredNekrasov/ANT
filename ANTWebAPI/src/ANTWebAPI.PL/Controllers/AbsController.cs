using Microsoft.AspNetCore.Mvc;

namespace ANTWebAPI.PL.Controllers;

/*
 * AbsController is an abstract class that provides common methods for all controllers
 */
public abstract class AbsController<D> : ControllerBase
{
    /*
     * GetListAsync is an abstract method that returns an ActionResult of ICollection<D>
     * 
     * @return an ActionResult of ICollection<D>
     */
    public abstract Task<ActionResult<ICollection<D>>> GetListAsync();
    /*
     * PutRecordAsync is an abstract method that returns an IActionResult
     * 
     * @param id the id of the record to update
     * @param dto the dto of the record to update
     * 
     * @return an IActionResult
     */
    public abstract Task<IActionResult> PutRecordAsync(long id, D dto);
    /*
     * PostRecordAsync is an abstract method that returns an IActionResult
     * 
     * @param dto the dto of the record to insert
     * 
     * @return an IActionResult
     */
    public abstract Task<IActionResult> PostRecordAsync(D dto);
    /*
     * DeleteRecordAsync is an abstract method that returns an IActionResult
     * 
     * @param id the id of the record to delete
     * 
     * @return an IActionResult
     */
    public abstract Task<IActionResult> DeleteRecordAsync(long id);
    /*
     * GetRecordAsync is an abstract method that returns an ActionResult of D
     * 
     * @param id the id of the record to get
     * 
     * @return an ActionResult of D
     */
    public abstract Task<ActionResult<D>> GetRecordAsync(long id);
}
