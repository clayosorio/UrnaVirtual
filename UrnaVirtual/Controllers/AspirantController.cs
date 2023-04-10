using Microsoft.AspNetCore.Mvc;
using UrnaVirtual.Modelos;
using UrnaVirtual.Servicios;
using UrnaVirtual.Servicios.IServicios;

namespace UrnaVirtual.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AspirantController : ControllerBase
    {
        IAspirantServices _aspirantServices;

        public AspirantController(IAspirantServices aspirantServices)
        {
            _aspirantServices = aspirantServices;
        }
        [HttpGet]
        public IActionResult GetAspirants()
        {
            return Ok(_aspirantServices.GetAspirants());
        }
        [HttpPost]
        public IActionResult SaveAspirant([FromBody] Aspirant aspirant)
        { 
            _aspirantServices.SaveAspirant(aspirant);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAspirant(Guid id)
        {
            _aspirantServices.DeleteAspirant(id);
            return Ok();    
        }
    }
}
