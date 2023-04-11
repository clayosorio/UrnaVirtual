using Microsoft.EntityFrameworkCore;
using UrnaVirtual.Modelos;
using UrnaVirtual.Servicios.IServicios;
using UrnaVirtual.UrnaVirtualContext;

namespace UrnaVirtual.Servicios
{
    public class AspirantServices : IAspirantServices
    {
        UVContext _uvContext;
		public List<Aspirant> aspirants = new List<Aspirant>();
        public List<Vote> votes = new List<Vote>();

		public AspirantServices(UVContext uvContext)
        {
            _uvContext = uvContext;
        }

        public IEnumerable<Aspirant> GetAspirants() 
        {
            return _uvContext.Aspirants;
        }

        public async Task SaveAspirant(Aspirant aspirant)
        {
            var targetAspirant = _uvContext.Aspirants.Where(p => p.ID == aspirant.ID);
            if (targetAspirant != null) { 
                throw new InvalidOperationException("Ya existe un aspirante con esta identificación"); 
            }
			aspirant.AspirantId = Guid.NewGuid();
			_uvContext.Add(aspirant);
			await _uvContext.SaveChangesAsync();

        }

        public async Task DeleteAspirant(Guid ID) 
        {
            var targetAspirant = _uvContext.Aspirants.Find(ID);

            if (targetAspirant != null) 
                _uvContext.Remove(targetAspirant); 
                await _uvContext.SaveChangesAsync();
        }

        public dynamic GetAspirantByID(string id)
        {
            var aspirant = _uvContext.Aspirants.Where(p => p.ID == id);
            return aspirant;
		}

        public async Task UpdateAspirantById(Aspirant aspirant, string id , bool updateId)
        {
            var targetAspirant = _uvContext.Aspirants.Where(p => p.ID == id).FirstOrDefault();
            var targetAspitantExist = _uvContext.Aspirants.Where(p => p.ID == aspirant.ID).FirstOrDefault();
			if (targetAspirant == null)
            {
				throw new InvalidOperationException("No existe un aspirante con esta identificación");
			}

            if (updateId && targetAspitantExist != null)
            {
				throw new InvalidOperationException("Ya existe un usuario con esta identificación nueva");

			}
			targetAspirant.FullNameAspirant = aspirant.FullNameAspirant;
			targetAspirant.ExpeditionDateID = aspirant.ExpeditionDateID;
            targetAspirant.ID = updateId ? aspirant.ID : targetAspirant.ID;
			targetAspirant.City = aspirant.City;
			targetAspirant.Departments = aspirant.Departments;
			await _uvContext.SaveChangesAsync();
		}

	}
}
