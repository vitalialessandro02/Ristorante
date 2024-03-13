using Ristorante.Models.Context;
using Ristorante.Models.Entities;
using Ristorante.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ristorante.Models.Repository 
{
    public class DettaglioOrdineRepository : GenericRepository<DettagliOrdine>
    {
        public DettaglioOrdineRepository(MyDbContext context) : base(context)
        { 

        }

        public List<DettagliOrdine> GetDettagliOrdine(int from, int num, out int totalNum, int? idPortata, int? idOrdine)
        {
            var query = _ctx.DettagliOrdini.AsQueryable();
            
            if (idPortata.HasValue)
            {
                query = query.Where(w => w.IdPortata.Equals(idPortata));
            }

            if(idOrdine.HasValue)
            {
                query = query.Where(w => w.IdOrdine.Equals(idOrdine));
            }

            totalNum = query.Count();

            return
                query
                .OrderBy(o => o.IdOrdine)
                .OrderBy(o => o.IdPortata)
                .Skip(from)
                .Take(num)
                .ToList();
        }
    }
}
