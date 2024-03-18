using Ristorante.Models.Entities;
using Ristorante.Models.Enumeration;

namespace Ristorante.Application.Models.Dtos
{
    public class PortataDto
    {
        public PortataDto() { }

        public PortataDto(Portata portata) 
        {
            Id = portata.Id;
            Nome = portata.Nome;
            Prezzo = portata.Prezzo;
            TipologiaPortata = portata.TipologiaPortata;
        }

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public double Prezzo { get; set; }
        public Tipologia TipologiaPortata { get; set; }
    }
}
