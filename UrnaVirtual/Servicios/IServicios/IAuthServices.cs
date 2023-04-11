using UrnaVirtual.Modelos;

namespace UrnaVirtual.Servicios.IServicios
{
	public interface IAuthServices
	{
		dynamic ValidateVoter(Auth auth);
	}
}
