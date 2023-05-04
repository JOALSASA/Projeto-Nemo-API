using Microsoft.AspNetCore.Mvc;

namespace Projeto_Nemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AquarioController : ControllerBase
    {
        
        [HttpGet]
        public String helloWorld() {
            return "Hello World";
        }
    }
}