using Ristorante.Models.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Models.Entities
{
    public class Portata
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public double Prezzo {  get; set; }
        public Tipologia TipologiaPortata { get; set; }
        
    }
}
