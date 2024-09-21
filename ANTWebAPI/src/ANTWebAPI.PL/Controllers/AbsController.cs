using Microsoft.AspNetCore.Mvc;

namespace ANTWebAPI.PL.Controllers;

public abstract class AbsController<D> : ControllerBase
{
    public abstract Task<ActionResult<ICollection<D>>> GetListAsync();

    public abstract Task<IActionResult> PutRecordAsync(long id, D dto);

    public abstract Task<IActionResult> PostRecordAsync(D dto);

    public abstract Task<IActionResult> DeleteRecordAsync(long id);

    public abstract Task<ActionResult<D>> GetRecordAsync(long id);
}
