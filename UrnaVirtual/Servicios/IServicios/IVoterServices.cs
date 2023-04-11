using UrnaVirtual.Modelos;

namespace UrnaVirtual.Servicios.IServicios
{
    public interface IVoterServices
    {
        IEnumerable<Voter> GetVoters();
        Task SaveVoter(Voter voter);
        dynamic ValidateVoter(string ID);

        Task DeleteVoterByID(string id);

	}
}
