using Microsoft.AspNetCore.Mvc;
using UrnaVirtual.Modelos;
using UrnaVirtual.Servicios.IServicios;

namespace UrnaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	public class AuthController : ControllerBase
	{
        private readonly string _authToken;
        private readonly IAuthServices _authServices;
        public AuthController(IConfiguration config, IAuthServices authServices)
        {
            _authToken = config.GetSection("settings").GetSection("secretkey").ToString();
            _authServices = authServices;
		}

        [HttpPost]
        [Route("validar")]

        public IActionResult ValidateVoter(Auth auth)
		{
            return Ok(_authServices.ValidateVoter(auth));
        }
    }
}
