using Ristorante.Models.Entities;

namespace Ristorante.Application.Models.Dtos
{
    public class OrdineDto
    {
        public OrdineDto() { }  

        public OrdineDto(Ordine ordine) {
            IdOrdine = ordine.IdOrdine;
            IdUtente = ordine.IdUtente; 
            DataOrdine = ordine.DataOrdine; 
            Indirizzo = ordine.Indirizzo;
        }


        public int IdOrdine { get; set; }
        public int IdUtente { get; set; }
        public DateTime DataOrdine { get; set; }
        public string Indirizzo { get; set; } = string.Empty;


    }
}
