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

        [HttpGet("{ID}")]
        public IActionResult ValidateVoter(Guid ID)
        {
            return Ok(_voterServices.ValidateVoter(ID));
        }
    }
}
