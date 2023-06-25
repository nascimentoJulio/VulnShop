
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WSS.VulnShop.WebApi.Controllers
{
  public class BaseController : ControllerBase
  {
    private IEnumerable<Claim> Claims => ((ClaimsIdentity)User.Identity).Claims;

    public string Email{ get => Claims.FirstOrDefault(claim => claim.Type == "client_email")?.Value ?? ""; }
  }
}
