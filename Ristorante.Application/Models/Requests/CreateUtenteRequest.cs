using Ristorante.Models.Entities;
using Ristorante.Models.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Application.Models.Requests
{
    public class CreateUtenteRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

 
        public Utente ToEntity()
        {
            var utente = new Utente();
            utente.Email = Email;
            utente.Nome = Nome;
            utente.Cognome = Cognome;
            utente.Password = Password;
            utente.RuoloUtente = Ruolo.Cliente;
         
            return utente;
        }
    }
}
