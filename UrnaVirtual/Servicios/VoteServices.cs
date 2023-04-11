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
            var voto = _urnaVirtual.Votes.Where(x => x.VoterId == vote.VoterId).FirstOrDefault();
            var aspirant = _urnaVirtual.Aspirants.Where(a => a.AspirantId == vote.AspirantId).FirstOrDefault();
            var voter = _urnaVirtual.Voters.Where(v => v.VoterId == vote.VoterId).FirstOrDefault(); 

            if (voto != null)
            {
				throw new InvalidOperationException("Ya existe un voto realizado con este votante.");
			}
            if (voter != null || aspirant != null)
            {
				throw new InvalidOperationException("No existe un votante o un aspirante con esta identificación");
			}
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
