using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly static string[] _customers = { "Vitor", "Max", "Jonh" };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customers);
        }
    }
}