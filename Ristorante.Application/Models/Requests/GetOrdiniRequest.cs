using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Application.Models.Requests
{
    public class GetOrdiniRequest
    {

        public int PageSize { get; set; } //Rappresenta la grandezza della pagina
        public int PageNumber { get; set; } //Identifica il numero della pagina ad indice 0

        public DateTime dataInizio { get; set; }

        public DateTime dataFine { get; set; }

        public string Email { get; set; }


    }
}
