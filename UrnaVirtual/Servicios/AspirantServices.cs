using UrnaVirtual.Modelos;
using UrnaVirtual.Servicios.IServicios;
using UrnaVirtual.UrnaVirtualContext;

namespace UrnaVirtual.Servicios
{
    public class AspirantServices : IAspirantServices
    {
        UVContext _uvContext;

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
    }
}
