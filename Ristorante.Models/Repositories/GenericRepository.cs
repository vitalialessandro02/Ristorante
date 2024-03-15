using Microsoft.EntityFrameworkCore.Query.Internal;
using Ristorante.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Models.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        protected MyDbContext _ctx;
        public GenericRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Aggiungi(T entity)
        {
            _ctx.Set<T>().Add(entity);
        }

        public void Modifica(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public T Ottieni(object id)
        {
            return _ctx.Set<T>()
                .Find(id);

        }

        public void Elimina(object id)
        {
            var entity = Ottieni(id);
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void Save()
        {
            _ctx.SaveChanges ();
        }

    }
}
