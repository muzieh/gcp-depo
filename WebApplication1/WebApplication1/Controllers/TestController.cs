using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class TestController : ControllerBase
{
    // GET
    [HttpGet("test")]
    public string Get() => "response asdf"; 
}