namespace keeper.Controllers;

[Route("api/[controller]")]
public class VaultsController : Controller
{
    private readonly VaultsService _vs;
    private readonly Auth0Provider _auth;

    public VaultsController(VaultsService vs, Auth0Provider auth)
    {
        _vs = vs;
        _auth = auth;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault data)
    {
        try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                data.CreatorId = userInfo.Id;
                Vault result = _vs.PostNewVault(data);
                return new ActionResult<Vault>(Ok(result));
                
            }
        catch (Exception e)
            {
              return BadRequest(e.Message);
            }
    }

    [HttpGet("{vaultId}")]
    [Authorize]
    public async Task<ActionResult<Vault>> GetVaultById(int vaultId){
        try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                Vault result = _vs.GetVaultById(vaultId, userInfo.Id);
                return new ActionResult<Vault>(Ok(result));
       
            }
        catch (Exception e)
            {
              return BadRequest(e.Message);
            }
    }

    [HttpPut("{vaultId}")]
    [Authorize]
    public async Task<ActionResult<Vault>> Edit(int vaultId, [FromBody] Vault data)
    {
        try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                data.CreatorId = userInfo.Id;
                data.Id = vaultId;
                data.Creator = userInfo;
                Vault vault = _vs.Edit(data);
                return Ok(vault);
            }
        catch (Exception e)
            {
              return BadRequest(e.Message);
            }
    }
}