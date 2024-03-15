using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ristorante.Application.Abstractions.Services;
using Ristorante.Application.Factories;
using Ristorante.Application.Models.Requests;
using Ristorante.Application.Models.Responses;
using Ristorante.Models.Entities;
using System.Security.Claims;

namespace Ristorante.Web.Controllers
{
        [ApiController]
        [Route("api/v1/[controller]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public class OrdineController : ControllerBase
        {

            private readonly IOrdineService _ordineService;
            public OrdineController(IOrdineService ordineService)
            {
                _ordineService = ordineService;
            }

        /*
            [HttpPost]
            [Route("newOrdine")]
            public IActionResult CreateOrdine(CreateOrdineRequest request)
            {
                var claimsIdentity = this.User.Identity as ClaimsIdentity;
                string idOrdine = claimsIdentity.Claims
                    .Where(w => w.Type == "Id").First().Value;
                var ordine = request.ToEntity();
                _ordineService.addOrdine(ordine);
                

                var response = new CreateUtenteResponse();
                response.Ordine = new Application.Models.Dtos.UtenteDto(ordine);
                return Ok(ResponseFactory
                    .WithSuccess(response)
                    );
            }
             */
            [HttpPost]
            [Route("listOrdini")]
            public IActionResult GetOrdine(GetOrdiniRequest request)
            {
            // TODO : Validazione della richiesta
                int totalNum = 0;
                var ordini = _ordineService.getOrdini(request.PageNumber * request.PageSize, request.PageSize, out totalNum, request.dataInizio, request.dataFine, request.idUtente);

                var response = new GetOrdineResponse();
                var pageFounded = (totalNum / (decimal)request.PageSize);
                response.NumeroPagine = (int)Math.Ceiling(pageFounded);
                response.OrdineDtos = ordini.Select(s =>
                new Application.Models.Dtos.OrdineDto(s)).ToList();


                 return Ok(ResponseFactory
                .WithSuccess(response)
                  );
            }


    }
}
