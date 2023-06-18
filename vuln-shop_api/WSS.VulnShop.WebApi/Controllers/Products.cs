using MediatR;
using Microsoft.AspNetCore.Mvc;
using WSS.VulnShop.Domain.Products.GetAllProducts;

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
      return Ok(result);
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

  }
}
