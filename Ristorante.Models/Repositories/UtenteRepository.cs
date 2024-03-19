using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ristorante.Models.Context;
using Ristorante.Models.Entities;
using Ristorante.Models.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ristorante.Models.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(MyDbContext context) : base(context)
        {

        }

        public List<Utente> GetUtenti(int from, int num, out int totalNum, int? idUtente)
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

        public int GetIdUtenteByEmail(string email)
        {
            var query = _ctx.Utenti.AsQueryable();
                query = query.Where(w => w.Email.Equals(email));
            int result = query.Select(w => w.Id).FirstOrDefault();
            return result == 0 ? -1 : result;
        }

        public bool UtenteExists(int id)
        {
            var query = _ctx.Utenti.AsQueryable();
            query = query.Where(w => w.Id.Equals(id));
            return query.Select(w => w.Id).Contains(id);
        }

    }
}
