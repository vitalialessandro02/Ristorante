using Ristorante.Application.Models.Dtos;

namespace Ristorante.Application.Models.Responses
{
    public class GetOrdineResponse
    {
        public List<OrdineDto> OrdineDtos { get; set; } = new List<OrdineDto>();
        public int NumeroPagine { get; set; }
    }
}
