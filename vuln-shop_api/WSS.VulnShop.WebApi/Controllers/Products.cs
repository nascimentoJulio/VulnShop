using Microsoft.AspNetCore.Mvc;

namespace WSS.VulnShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
