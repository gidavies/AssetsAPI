using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class AssetsController : ControllerBase
{
  private readonly AssetContext _context;
 
  public AssetsController(AssetContext context)
  {
    _context = context;
 
    if (_context.Assets.Any()) return;
 
    AssetSeed.InitData(context);
  }

  [HttpGet]
  [Route("")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public ActionResult<IQueryable<Asset>> GetProducts()
  {
    var result = _context.Assets as IQueryable<Asset>;
 
    return Ok(result.OrderBy(a => a.AssetNumber));
  }
}