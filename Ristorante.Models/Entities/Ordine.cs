using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Models.Entities
{
    public class Ordine
    {

        public int IdOrdine { get; set; }
        public int IdUtente { get; set; }
        public DateTime DataOrdine { get; set; }
        public string Indirizzo { get; set; } = string.Empty;

        public virtual Utente UtenteCheOrdina{ get; set; }

       
    }
}
