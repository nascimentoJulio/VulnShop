﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WSS.VulnShop.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class Purchase : ControllerBase
  {
    private readonly IMediator _mediator;

    public Purchase(IMediator mediator)
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

    // POST api/<Purchase>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }
  }
}
