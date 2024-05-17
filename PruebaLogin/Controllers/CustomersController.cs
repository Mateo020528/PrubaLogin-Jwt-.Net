using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization; //Este se genera con el metodo Authorize

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet, Authorize]
        public IEnumerable <string> Get()
        {
            return new string [] {" Jhon Doe ", "Chandrashekhar Singh"};
        }
    }

    