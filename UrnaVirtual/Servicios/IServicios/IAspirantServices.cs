using UrnaVirtual.Modelos;

namespace UrnaVirtual.Servicios.IServicios
{
    public interface IAspirantServices
    {
        IEnumerable<Aspirant> GetAspirants();
        Task SaveAspirant(Aspirant aspirant);
        Task DeleteAspirant(Guid ID);
    }
}
