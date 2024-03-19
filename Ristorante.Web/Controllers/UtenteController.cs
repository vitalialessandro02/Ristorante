using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ristorante.Application.Abstractions.Services;
using Ristorante.Application.Factories;
using Ristorante.Application.Models.Requests;
using Ristorante.Application.Models.Responses;
using System.Security.Claims;

namespace Ristorante.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtenteController:ControllerBase
    {

        private readonly IUtenteService _utenteService;
        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }


        [HttpPost]
        [Route("newUtente")]
        public IActionResult  CreateUtente(CreateUtenteRequest request)
        {
            var utente = request.ToEntity();
             _utenteService.AddUtente(utente);
            var response = new CreateUtenteResponse();
            response.Utente = new Application.Models.Dtos.UtenteDto(utente);
            return Ok(ResponseFactory
                .WithSuccess(response)
                );
        }

    }





}
