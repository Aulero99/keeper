namespace keeper.Controllers;

[Route("api/[controller]")]
public class VaultsController : Controller
{
    private readonly VaultsService _vs;

    public VaultsController(VaultsService vs)
    {
        _vs = vs;
    }

    [HttpGet]
    public ActionResult<List<string>> Get()
    {
        try
        {
            return Ok(new List<string>() { "Vaults 1", "Vaults 2" });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
