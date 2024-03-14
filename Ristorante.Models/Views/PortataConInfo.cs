using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ristorante.Models.Enumeration;

namespace Ristorante.Models.Views
{
    public class PortataConInfo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public double Prezzo { get; set; }
        public Tipologia TipologiaPortata { get; set; }
        public int Quantita {  get; set; }

        public PortataConInfo (int Id, string Nome, double Prezzo, Tipologia TipologiaPortata, int Quantita)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Prezzo = Prezzo;
            this.TipologiaPortata = TipologiaPortata;
            this.Quantita = Quantita;
        }
    }
}
