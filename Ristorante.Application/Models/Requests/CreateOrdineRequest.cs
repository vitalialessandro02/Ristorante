using Ristorante.Models.Context;
using Ristorante.Models.Entities;
using Ristorante.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Application.Models.Requests
{
    public class CreateOrdineRequest
    {
        public string Indirizzo { get; set; } = string.Empty;
        public List <int> Portate { get; set; }
        public List<int> Quantita { get; set; }


        public Ordine ToEntity(int idUtente)
        {
            var ordine = new Ordine();
            ordine.DataOrdine = DateTime.Now;
            ordine.IdUtente = idUtente;
            ordine.Indirizzo = Indirizzo;
           
            return ordine;
        }




    }
}
