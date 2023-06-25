using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSS.VulnShop.Domain.Cart.AddInCart;
using WSS.VulnShop.Domain.Cart.GetCart;

namespace WSS.VulnShop.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class Cart : BaseController
  {
    private readonly IMediator _mediator;

    public Cart(IMediator mediator)
    {
      _mediator = mediator;
    }

    [Authorize]
    [HttpGet] 
    public async Task<IActionResult> GetCartByUser()
    {
      var command = new GetCartCommand{ Email = Email};
      var result = await _mediator.Send(command);
      if (result is null)
        return NoContent();

      return Ok(result);
    }

    [HttpPost("/add")]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] AddInCartCommand command)
    {
      command.Email = Email; 
      var result = await _mediator.Send(command);
      if (result is 0)
        return BadRequest();

      return Ok(result);
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
