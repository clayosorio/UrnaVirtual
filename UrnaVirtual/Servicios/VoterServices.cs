using UrnaVirtual.Modelos;
using UrnaVirtual.Servicios.IServicios;
using UrnaVirtual.UrnaVirtualContext;

namespace UrnaVirtual.Servicios
{
    public class VoterServices : IVoterServices
    {
        UVContext _uvContext;

        public VoterServices(UVContext uvContext)
        {
            _uvContext = uvContext;
        }

        public IEnumerable<Voter> GetVoters() 
        {
            return _uvContext.Voters;
        }

        public async Task SaveVoter(Voter voter) 
        {
            _uvContext.Add(voter);
            await _uvContext.SaveChangesAsync();    
        }

        public dynamic ValidateVoter(Guid ID)
        {
            var targetVoter = _uvContext.Voters.Find(ID);
            
            if (targetVoter != null) 
            {
                return $"Votante con numero de identificación {targetVoter.ID} validado exitosamente";
            }

            return $"Votante con identificacion {ID} no encontrado :c";
        }
    }
}
