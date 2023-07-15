namespace keeper.Controllers;

[Route("api/[controller]")]
public class VaultKeepsController : Controller
{
    private  readonly VaultKeepsService _vks;
    private readonly Auth0Provider _auth;

    public VaultKeepsController(VaultKeepsService vks, Auth0Provider auth)
    {
        _vks = vks;
        _auth = auth;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep data)
    {
        try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                data.CreatorId = userInfo.Id;
                VaultKeep result = _vks.Post(data);
                return new ActionResult<VaultKeep>(Ok(result));
            }
        catch (Exception e)
            {
              return BadRequest(e.Message);
            }
    }
}