using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using Ristorante.Application.Abstractions.Services;
using Ristorante.Application.Factories;
using Ristorante.Application.Models.Requests;
using Ristorante.Application.Models.Responses;
using Ristorante.Models.Entities;
using Ristorante.Models.Enumeration;
using System.Runtime.Serialization;
using System.Security.Claims;

namespace Ristorante.Web.Controllers
{
        [ApiController]
        [Route("api/v1/[controller]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public class OrdineController : ControllerBase
        {

            private readonly IOrdineService _ordineService;
            private readonly IPortataService _portataService;
            public OrdineController(IOrdineService ordineService, IPortataService portataService)
            {
                _ordineService = ordineService;
                _portataService = portataService;
            
            }

            [HttpPost]
            [Route("getPortate")]
            public IActionResult GetPortate(GetPortateRequest request)
            {
                int totalNum = 0;
                var portate = _portataService.GetPortate(request.PageNumber * request.PageSize, request.PageSize,
                    out totalNum, Enum.Parse<Tipologia>(request.TipologiaPortate, true));
                var response = new GetPortateResponse();
                var pageFounded = (totalNum / (decimal)request.PageSize);
                response.NumeroPagine = (int)Math.Ceiling(pageFounded);
                response.PortataDtos = portate.Select(s =>
                new Application.Models.Dtos.PortataDto(s)).ToList();
                return Ok(ResponseFactory
                .WithSuccess(response)
                );
            }
        
            [HttpPost]
            [Route("newOrdine")]
            public IActionResult CreateOrdine(CreateOrdineRequest request)
            {
                var claimsIdentity = this.User.Identity as ClaimsIdentity;
                string idUtente = claimsIdentity.Claims
                    .Where(w => w.Type == "Id").First().Value;
                var ordine = request.ToEntity(Int32.Parse(idUtente));
                _ordineService.AddOrdine(ordine, request.Portate, request.Quantita);
                var prezzo = _ordineService.GetPrezzo();
                var NumeroOrdine = _ordineService.GetNumeroOrdine(); 
                var response = new CreateOrdineResponse();
                response.Ordine = new Application.Models.Dtos.OrdineCreatoDto(prezzo,NumeroOrdine);
                return Ok(ResponseFactory
                    .WithSuccess(response)
                    );
            }
            
            [HttpPost]
            [Route("getOrdini")]
            public IActionResult GetOrdine(GetOrdiniRequest request)
            {
                int totalNum = 0;
                var claimsIdentity = this.User.Identity as ClaimsIdentity;
                string idUtente = claimsIdentity.Claims
                    .Where(w => w.Type == "Id").First().Value;
                var ordini = _ordineService.GetOrdini(request.PageNumber * request.PageSize, request.PageSize,
                out totalNum, request.DataInizio, request.DataFine, Int32.Parse(idUtente), request.IdUtenteDaVisualizzare);
                var response = new GetOrdiniResponse();
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
