using Microsoft.AspNetCore.Mvc;
using UrnaVirtual.Modelos;
using UrnaVirtual.Servicios;
using UrnaVirtual.Servicios.IServicios;

namespace UrnaVirtual.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoteController : ControllerBase
    {
        IVoteServices _voteServices;

        public VoteController(IVoteServices voteServices) 
        {
            _voteServices = voteServices;
        }
        [HttpGet]
        public IActionResult GetAllVotes()
        {
            return Ok(_voteServices.GetAllVotes());
        }

        [HttpPost]
        public IActionResult SaveVote([FromBody] Vote vote)
        {
            _voteServices.SaveVote(vote);
            return Ok();
        }
    }
}
