using UrnaVirtual.Modelos;
using UrnaVirtual.Servicios.IServicios;
using UrnaVirtual.UrnaVirtualContext;

namespace UrnaVirtual.Servicios
{
    public class VoteServices : IVoteServices
    {
        UVContext _urnaVirtual;

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
    }
}
