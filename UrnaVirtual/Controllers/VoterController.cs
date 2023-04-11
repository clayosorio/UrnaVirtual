using Microsoft.AspNetCore.Mvc;
using UrnaVirtual.Modelos;
using UrnaVirtual.Servicios;
using UrnaVirtual.Servicios.IServicios;

namespace UrnaVirtual.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoterController : ControllerBase
    {
        IVoterServices _voterServices;

        public VoterController(IVoterServices voterServices)
        {
            _voterServices = voterServices;
        }
        [HttpGet]
        public IActionResult GetVoters()
        {
            return Ok(_voterServices.GetVoters());
        }

        [HttpPost]
        public IActionResult SaveVoter(Voter voter)
        {
            _voterServices.SaveVoter(voter);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult ValidateVoter(string id)
        {
            return Ok(_voterServices.ValidateVoter(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVoterByID(string id)
        {
            _voterServices.DeleteVoterByID(id);
            return Ok();
        }

    }
}
