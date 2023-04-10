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
            _urnaVirtual.Add(vote);
            await _urnaVirtual.SaveChangesAsync();
        }

        public dynamic GetVotesByAspirant(Guid id) 
        {
            votes = _urnaVirtual.Votes.ToList();
            return votes.Where(p => p.AspirantId == id);
        }
    }
}
