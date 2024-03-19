using Ristorante.Models.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Models.Entities
{
    public class Utente
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public virtual ICollection< Ordine> Ordini { get; set; }
        public Ruolo RuoloUtente { get; set; }

    }
}
