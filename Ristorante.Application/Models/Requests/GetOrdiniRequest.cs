using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Application.Models.Requests
{
    public class GetOrdiniRequest
    {

        public int PageSize { get; set; } //Rappresenta la grandezza della pagina
        
        public int PageNumber { get; set; } //Identifica il numero della pagina ad indice 0

        public DateTime DataInizio { get; set; }

        public DateTime DataFine { get; set; }
        
        public int IdUtenteDaVisualizzare { get; set; }

    }
}
