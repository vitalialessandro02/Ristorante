namespace Ristorante.Application.Models.Dtos
{
    public class OrdineCreatoDto
    {
        public OrdineCreatoDto() { }    

        public OrdineCreatoDto(double prezzo,int numeroOrdine) {
        Prezzo= prezzo;
        NumeroOrdine = numeroOrdine;
        
        }




        public int NumeroOrdine { get; set; }
        public double Prezzo { get; set; }
    }
}
