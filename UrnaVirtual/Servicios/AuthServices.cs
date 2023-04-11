using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UrnaVirtual.Modelos;
using UrnaVirtual.Servicios.IServicios;
using UrnaVirtual.UrnaVirtualContext;

namespace UrnaVirtual.Servicios
{
	public class AuthServices : IAuthServices
	{
		UVContext _urnaVirtual;
		private readonly string _authToken;
		public AuthServices(UVContext urnaVirtual, IConfiguration config)
		{
			_urnaVirtual = urnaVirtual;
			_authToken = config.GetSection("settings").GetSection("secretkey").ToString();
		}
		public dynamic ValidateVoter(Auth auth)
		{
			var voter = _urnaVirtual.Voters.Where(p => p.ID == auth.Identificacion).FirstOrDefault();

			if (voter == null)
			{
				return new {
					error = false,
					message = "Usuario no encontrado."
				};
			}

			var keyBytes = Encoding.ASCII.GetBytes(_authToken);
			var claims = new ClaimsIdentity();

			claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, auth.Identificacion));

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = claims,
				Expires = DateTime.UtcNow.AddMinutes(10),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

			var tokenCreated = tokenHandler.WriteToken(tokenConfig);
			return new
			{
				token = tokenCreated
			};
		}
	}
}
