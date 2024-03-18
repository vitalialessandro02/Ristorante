using Ristorante.Application.Models.Dtos;

namespace Ristorante.Application.Models.Responses
{
    public class GetPortateResponse
    {
        public List<PortataDto> PortataDtos { get; set; } = new List<PortataDto>();
        public int NumeroPagine { get; set; }
    }
}
