using UrnaVirtual.Modelos;

namespace UrnaVirtual.Servicios.IServicios
{
    public interface IVoteServices
    {
        IEnumerable<Vote> GetAllVotes();
        Task SaveVote(Vote vote);

    }
}
