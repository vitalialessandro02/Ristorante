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
        public float Prezzo {  get; set; }
        public Tipologia Tipologia { get; set; }
        
    }
}
