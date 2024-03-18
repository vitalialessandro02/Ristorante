using Ristorante.Models.Enumeration;

namespace Ristorante.Application.Models.Requests
{
    public class GetPortateRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        //public Tipologia? Tipologia { get; set; }
    }
}
