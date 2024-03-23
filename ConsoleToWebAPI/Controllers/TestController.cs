using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controllers
{
    [ApiController]
    [Route("test/[action]")]
    public class TestController : ControllerBase
    {
        public string Get()
        {
            return "<h3>Hello from get</h3>";
        }
        public string Get1()
        {
            return "<h3>Hello from get1</h3>";
        }
    }
}
