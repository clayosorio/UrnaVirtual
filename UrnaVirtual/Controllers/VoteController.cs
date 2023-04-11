using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrnaVirtual.Modelos;
using UrnaVirtual.Servicios;
using UrnaVirtual.Servicios.IServicios;

namespace UrnaVirtual.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
            return Ok(_voteServices.SaveVote(vote));
        }
		[HttpGet("{id}")]
		public IActionResult GetVotesByAspirant(string id)
        {
            return Ok(_voteServices.GetVotesByAspirant(id));
        }

	}
}
