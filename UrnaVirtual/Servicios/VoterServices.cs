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
			var targetAspirant = _uvContext.Voters.Where(p => p.ID == voter.ID).FirstOrDefault();
			if (targetAspirant != null)
			{
				throw new InvalidOperationException("Ya existe un votante con esta identificación");
			}
			voter.VoterId = Guid.NewGuid();
            _uvContext.Add(voter);
            await _uvContext.SaveChangesAsync();    
        }

        public dynamic ValidateVoter(string id)
        {
            var targetVoter = _uvContext.Voters.Where(p => p.ID == id).FirstOrDefault();
            
            if (targetVoter != null) 
            {
                return $"Votante con numero de identificación {targetVoter.ID} validado exitosamente, ve y vota, pa!";
            }

            return $"Votante con identificacion {id} no encontrado :c";
        }

        public async Task DeleteVoterByID(string id)
        { 
            var targetVoter = _uvContext.Voters.Where(p => p.ID == id).FirstOrDefault();

            if (targetVoter == null)
            {
				throw new InvalidOperationException($"El votante con identidad {id} no existe en la bd.");
            }
			_uvContext.Remove(targetVoter);
            await _uvContext.SaveChangesAsync();    
		}
    }
}
