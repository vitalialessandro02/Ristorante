using Ristorante.Models.Context;
using Ristorante.Models.Entities;
using Ristorante.Models.Enumeration;
using Ristorante.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Models.Repositories
{
    public class PortataRepository : GenericRepository<Portata>
    {
        public PortataRepository(MyDbContext context) : base(context) { 
        
        }

        public List<Portata> GetPortate(List<int> portate)
        {
            var query = _ctx.Portate.AsQueryable();
            query = query.Where(x=>portate.Contains(x.Id));
            return
              query
              .OrderBy(w => w.TipologiaPortata)
              .OrderBy(o => o.Id)
              .ToList();
        }



        public List<Portata> GetPortate(int from, int num, out int totalNum, Tipologia? tipologia)
        {
            var query = _ctx.Portate.AsQueryable();

            if (tipologia.HasValue)
            {
                query = query.Where(w => w.TipologiaPortata.Equals(tipologia));
            }
           
            totalNum = query.Count();

            return
                query
                .OrderBy(w=> w.TipologiaPortata)
                .OrderBy(o => o.Id)
                .Skip(from)
                .Take(num)
                .ToList();
        }

        public List<Portata> GetPortateByPrezzo(int from, int num, out int totalNum,double? prezzoMin, double? prezzoMax, int? tipologia)
        {

            var query = _ctx.Portate.AsQueryable();


            if(prezzoMin.HasValue)
            {
                query = query.Where(w => w.Prezzo >= prezzoMin);
            }
            if(prezzoMax.HasValue)
            {
                query = query.Where(w => w.Prezzo <= prezzoMax);
            }
            if(tipologia.HasValue)
            {
                Tipologia tipologia1 = (Tipologia)tipologia;

                query = query.Where(w => w.TipologiaPortata.Equals(tipologia1));
            }

            totalNum = query.Count();

            return
                  query
                  .OrderBy(o => o.TipologiaPortata)
                  .OrderBy(o => o.Prezzo)
                  .Skip(from)
                  .Take(num)
                  .ToList();
        }

        public bool PortateExists(List<int> ids)
        {
            List<Portata> portate = GetPortate(ids);
            return portate.Count == ids.Count;
        }
    }
}
