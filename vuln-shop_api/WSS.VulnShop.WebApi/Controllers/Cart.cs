using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSS.VulnShop.Domain.Cart.AddInCart;
using WSS.VulnShop.Domain.Cart.GetCart;
using WSS.VulnShop.Domain.Cart.UpdateItemQuantity;

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

    [HttpPost("add")]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] AddInCartCommand command)
    {
      command.Email = Email; 
      var result = await _mediator.Send(command);
      if (result is 0)
        return BadRequest();

      return Ok(result);
    }

    [Authorize]
    [HttpPut("alter")]
    public async Task<IActionResult> Put([FromBody] UpdateItemQuantityCommand command)
    {
      command.Email = Email;
      var result = await _mediator.Send(command);
      if (result is 0)
        return BadRequest();

      return Ok(result);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
