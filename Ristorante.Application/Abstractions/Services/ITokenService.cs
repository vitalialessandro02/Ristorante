

using Ristorante.Application.Models.Requests;

namespace Ristorante.Application.Abstractions.Services
{
    public interface ITokenService
    {
        string CreateToken(CreateTokenRequest request);
    }
}
