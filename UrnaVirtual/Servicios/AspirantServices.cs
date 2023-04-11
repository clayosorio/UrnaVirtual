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

        public dynamic GetAspirantByID(Guid id)
        {
            var aspirant = _uvContext.Aspirants.Find(id);
            return aspirant;
		}

        public async Task UpdateAspirantById(Aspirant aspirant, Guid id)
        {
            var targetAspirant = _uvContext.Aspirants.Find(id);


			if (targetAspirant != null)
            {
                targetAspirant.FullNameAspirant = aspirant.FullNameAspirant;
                targetAspirant.ID = aspirant.ID;
                targetAspirant.ExpeditionDateID = aspirant.ExpeditionDateID;
                targetAspirant.City = aspirant.City;
                targetAspirant.Departments = aspirant.Departments;
				await _uvContext.SaveChangesAsync();
			}
		}

	}
}
