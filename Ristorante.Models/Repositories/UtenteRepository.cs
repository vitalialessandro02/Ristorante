using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ristorante.Models.Context;
using Ristorante.Models.Entities;
using Ristorante.Models.Repositories;

namespace Ristorante.Models.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(MyDbContext context) : base(context)
        {

        }

        public List<Utente> getUtenti(int from, int num, out int totalNum, int? idUtente)
        {
            var query = _ctx.Utenti.AsQueryable();
            if (idUtente.HasValue)
            {
                query = query.Where(w => w.Id.Equals(idUtente));
            }
            totalNum = query.Count();

            return
                query
                .OrderBy(o => o.Id)
                .Skip(from)
                .Take(num)
                .ToList();
        }

    }
}
