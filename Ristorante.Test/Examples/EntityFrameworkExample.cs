using Microsoft.EntityFrameworkCore;
using Ristorante.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Test.Examples
{
    public class EntityFrameworkExample
    {
        public void RunExample()
        {
            var ctx = new MyDbContext();
            var ordini = ctx.Ordini.ToList();
            var utenti = ctx.Utenti.ToList();
            var portate = ctx.Portate.ToList();
            var dettagliOrdini = ctx.DettagliOrdini.ToList();
        }
    }
}
