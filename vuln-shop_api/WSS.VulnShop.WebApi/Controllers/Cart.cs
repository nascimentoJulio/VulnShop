using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WSS.VulnShop.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class Cart : ControllerBase
  {
    private readonly IMediator _mediator;

    public Cart(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("{idUser}")]
    public string GetCart(int idUser)
    {
      return "value";
    }

    [HttpPost("/add")]
    public void AddInCart([FromBody] string value)
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
