using Ristorante.Models.Context;
using Ristorante.Models.Entities;
using Ristorante.Models.Enumeration;
using Ristorante.Models.Repositories;
using Ristorante.Models.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Models.Repositories
{
    public class OrdineRepository : GenericRepository<Ordine>
    {
        public OrdineRepository(MyDbContext context) : base(context)
        {
        
        }

        public List<Ordine> GetOrdine(int from, int num, out int totalNum,DateTime dataInizio, DateTime dataFine, int idUtente)
        {
            var queryOrdine = _ctx.Ordini.AsQueryable();
            var queryUtente = _ctx.Utenti.AsQueryable();
            var ruolo = queryUtente.Where(w => w.Id.Equals(idUtente)).Select(w => w.RuoloUtente).FirstOrDefault();
            
            if(ruolo.Equals(Ruolo.Cliente))
            {
                queryOrdine = queryOrdine.Where(w => (w.DataOrdine >= dataInizio) && 
                (w.DataOrdine <= dataFine) && (w.IdUtente.Equals(idUtente)));
            } 
            else
            {
                queryOrdine = queryOrdine.Where(w => (w.DataOrdine >= dataInizio) && (w.DataOrdine <= dataFine));
            }

            totalNum = queryOrdine.Count();

            return
                queryOrdine
                 .OrderBy(o => o.DataOrdine)
                 .Skip(from)
                 .Take(num)
                 .ToList();

        }

        public List<PortataConInfo> GetPortateByIdOrdine(int from, int num, out int totalNum, int idOrdine)
        {
            var portate = _ctx.Portate.AsQueryable();
             
            var dettagliOrdini = _ctx.DettagliOrdini.AsQueryable();

            dettagliOrdini = dettagliOrdini.Where(w => w.IdOrdine.Equals(idOrdine));

            var elencoIndiciPortate = dettagliOrdini.Select(w => w.IdPortata).ToList();

            var portateScelte = dettagliOrdini.Join(
                portate,
                x => x.IdPortata,
                y => y.Id,
                (x, y) => new
                {
                    y.Id,
                    y.Nome,
                    y.Prezzo,
                    y.TipologiaPortata,
                    x.Quantita
                }).ToList();

            List<PortataConInfo> elencoPortate = new List<PortataConInfo>();

            foreach(var item in portateScelte) 
            {
                PortataConInfo portataConInfo = 
                    new PortataConInfo(item.Id,item.Nome,item.Prezzo,item.TipologiaPortata,item.Quantita);
                elencoPortate.Add(portataConInfo);
            }

            totalNum = elencoPortate.Count();

            return
                elencoPortate
                 .OrderBy(o => o.Id)
                 .Skip(from)
                 .Take(num)
                 .ToList();
        }


    }
}
