

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ristorante.Application.Models.Requests;
using Ristorante.Application.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ristorante.Application.Abstractions.Services
{
    public class TokenService:ITokenService
    {
        private readonly JwtAuthenticationOption _jwtAuthOption;
        public TokenService(IOptions<JwtAuthenticationOption> jwtAuthOption)
        {
            _jwtAuthOption = jwtAuthOption.Value;
        }
        //Pacchetti nuget necessari  System.IdentityModel.Tokens.Jwt
        public string CreateToken(CreateTokenRequest request)
        {
            //STEP 1 : Verificare esattezza della coppia username/password
            //TODO : Effettuare la verifica
            //STEP 2 : Se username/password corrette creo il token con le claims necessarie
            //TODO : Prendere i parametri dalla configurazione
            //TODO : Prendere le claims dal database

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Id", "3"));
            claims.Add(new Claim("Email", "efklvn"));
            claims.Add(new Claim("Nome", "epkn"));
            claims.Add(new Claim("Cognome", "èpeorg"));
            claims.Add(new Claim("Password", "opirj"));
            claims.Add(new Claim("Ruolo", "1"));

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
            //STEP 3 : Restituisco il token
            return token;
        }
    }
}
