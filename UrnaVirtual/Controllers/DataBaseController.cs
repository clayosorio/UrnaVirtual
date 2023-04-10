using Microsoft.AspNetCore.Mvc;
using UrnaVirtual.UrnaVirtualContext;

namespace UrnaVirtual.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataBaseController : ControllerBase
    {
        UVContext _uvContext;
        public DataBaseController(UVContext uvContext)
        {
            _uvContext = uvContext;
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDatabase()
        {
            _uvContext.Database.EnsureCreated();
            return Ok();
        }
    }
}
