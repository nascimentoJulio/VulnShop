using MediatR;
using Microsoft.AspNetCore.Mvc;
using WSS.VulnShop.Domain.Products.GetAllProducts;
using WSS.VulnShop.Domain.Products.NovaPasta;

namespace WSS.VulnShop.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class Products : ControllerBase
  {
    private readonly IMediator _mediator;

    public Products(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetProductsCommand command)
    {
      var result = await _mediator.Send(command);
      if (result == null)
        return BadRequest();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {

      var result = await _mediator.Send(new GetByIdCommand { Id = id});
      if (result == null)
        return BadRequest();
      return Ok(result);
    }

  }
}
