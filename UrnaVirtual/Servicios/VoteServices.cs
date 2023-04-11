using UrnaVirtual.Modelos;
using UrnaVirtual.Servicios.IServicios;
using UrnaVirtual.UrnaVirtualContext;

namespace UrnaVirtual.Servicios
{
    public class VoteServices : IVoteServices
    {
        UVContext _urnaVirtual;
        public List<Vote> votes = new List<Vote>(); 

        public VoteServices(UVContext urnaVirtual)   
        {
            _urnaVirtual = urnaVirtual;
        }

        public IEnumerable<Vote> GetAllVotes()
        {
            return _urnaVirtual.Votes;
        }

        public async Task SaveVote(Vote vote) 
        {
            vote.VoteId = Guid.NewGuid();
            _urnaVirtual.Add(vote);
            await _urnaVirtual.SaveChangesAsync();
        }

        public dynamic GetVotesByAspirant(string id) 
        {
			var resultado = from votes in _urnaVirtual.Votes
							join aspirtants in _urnaVirtual.Aspirants on votes.AspirantId equals aspirtants.AspirantId
							where aspirtants.ID == id
                            select votes;

            return resultado;

			//votes = _urnaVirtual.Votes.ToList();
			//return votes.Where(p => p.AspirantId == id);
		}
    }
}
