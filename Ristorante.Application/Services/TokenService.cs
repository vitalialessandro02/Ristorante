

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ristorante.Application.Models.Requests;
using Ristorante.Application.Options;
using Ristorante.Models.Context;
using Ristorante.Models.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ristorante.Application.Abstractions.Services
{
    public class TokenService:ITokenService
    {
        private readonly JwtAuthenticationOption _jwtAuthOption;
        private readonly UtenteRepository _utenteRepository;
        public TokenService(IOptions<JwtAuthenticationOption> jwtAuthOption)
        {
            _jwtAuthOption = jwtAuthOption.Value;
            _utenteRepository = new UtenteRepository(new MyDbContext());
        }
        public string CreateToken(CreateTokenRequest request)
        {
            int idUtente = _utenteRepository.GetIdUtenteByCredentials(request.Username, request.Password);
            var utente = _utenteRepository.Ottieni(idUtente);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Id", utente.Id.ToString()));
            claims.Add(new Claim("Nome", utente.Nome.ToString()));
            claims.Add(new Claim("Cognome", utente.Cognome.ToString()));
            claims.Add(new Claim("Ruolo", utente.RuoloUtente.ToString()));

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtAuthOption.Key)
                );
            var credentials = new SigningCredentials(securityKey
                , SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(_jwtAuthOption.Issuer
                , null
                , claims
                , expires: DateTime.Now.AddMinutes(30)
                , signingCredentials: credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
