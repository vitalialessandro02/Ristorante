using Ristorante.Models.Entities;
using Ristorante.Models.Enumeration;

namespace Ristorante.Application.Models.Dtos
{
    public class UtenteDto
    {

        public UtenteDto() { }

        public UtenteDto(Utente utente) 
        { 
         Id = utente.Id;
            Email = utente.Email;
            Nome = utente.Nome;
            Cognome = utente.Cognome;
            Password = utente.Password;
            Ruolo = utente.RuoloUtente;
        
        }

        public int Id { get; set; } 
        public string Email {  get; set; }=string.Empty;
        public string Nome {  get; set; } = string.Empty;
        public string Cognome {  get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
        public Ruolo Ruolo { get; set; }

    }
}
