using Ristorante.Models.Context;
using Ristorante.Models.Entities;
using Ristorante.Models.Enumeration;
using Ristorante.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Models.Repository
{
    public class OrdineRepository : GenericRepository<Ordine>
    {
        public OrdineRepository(MyDbContext context) : base(context)
        {
        
        }

        public List<Ordine> GetOrdine(int from, int num, out int totalNum,DateTime dataInizio, DateTime dataFine, int? idUtente)
        {
            var query = _ctx.Ordini.AsQueryable();

            if(idUtente.HasValue)
            {
                query = query.Where(w => w.IdOrdine.Equals(idUtente));
            }

            query = query.Where(w => (w.DataOrdine >= dataInizio) && (w.DataOrdine <= dataFine));

            totalNum = query.Count();

            return
                query
                 .OrderBy(o => o.DataOrdine)
                 .Skip(from)
                 .Take(num)
                 .ToList();

        }

        public List<Portata> GetPortateByIdOrdine(int from, int num, out int totalNum, int idOrdine)
        {
            var portate = _ctx.Portate.AsQueryable();
             
            var dettagliOrdini = _ctx.DettagliOrdini.AsQueryable();

            dettagliOrdini = dettagliOrdini.Where(w => w.IdOrdine.Equals(idOrdine));

            var elencoIndiciPortate = dettagliOrdini.Select(w => w.IdPortata).ToList();

            List<Portata>elencoPortate = new List<Portata>();

            foreach(int i in elencoIndiciPortate) 
            {
                var Portata = portate.FirstOrDefault(w => w.Id == i);
                elencoPortate.Add(Portata);
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
