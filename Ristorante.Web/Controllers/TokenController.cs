using Microsoft.AspNetCore.Mvc;
using Ristorante.Application.Abstractions.Services;
using Ristorante.Application.Factories;
using Ristorante.Application.Models.Requests;
using Ristorante.Application.Models.Responses;


namespace Ristorante.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TokenController : Controller
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateTokenRequest request)
        {
            
            string token = _tokenService.CreateToken(request);
            return Ok(
                ResponseFactory.WithSuccess(
                    new CreateTokenResponse(token)
                    )
                );
        }
    }
}
