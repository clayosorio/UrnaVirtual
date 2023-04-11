using Microsoft.AspNetCore.Mvc;
using UrnaVirtual.Modelos;
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
            return Ok(_aspirantServices.SaveAspirant(aspirant));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAspirant(Guid id)
        {
            _aspirantServices.DeleteAspirant(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetAspirantByID(string id)
        {
            return Ok(_aspirantServices.GetAspirantByID(id));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAspirantById([FromBody] Aspirant aspirant, string id, [FromQuery] bool updateId = false)
        {
            _aspirantServices.UpdateAspirantById(aspirant, id, updateId);
            return Ok();
        }
    }
}
