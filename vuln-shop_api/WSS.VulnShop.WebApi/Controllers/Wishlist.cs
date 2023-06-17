using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WSS.VulnShop.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class Wishlist : ControllerBase
  {
    private readonly IMediator _mediator;

    public Wishlist(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string [] { "value1", "value2" };
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
