using Ristorante.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Application.Models.Requests
{
    public class CreateOrdineRequest
    {
        public int IdUtente { get; set; }
        public DateTime DataOrdine { get; set; }
        public string Indirizzo { get; set; } = string.Empty;


        public Ordine ToEntity()
        {
            var ordine = new Ordine();
            ordine.DataOrdine = DataOrdine;
            ordine.IdUtente = IdUtente;
            ordine.Indirizzo = Indirizzo;
           
            return ordine;
        }




    }
}
