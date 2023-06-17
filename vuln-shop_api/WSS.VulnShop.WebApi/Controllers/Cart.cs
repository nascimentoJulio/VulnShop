using Microsoft.AspNetCore.Mvc;


namespace WSS.VulnShop.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class Cart : ControllerBase
  {

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
