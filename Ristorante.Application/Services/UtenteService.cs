using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ristorante.Application.Abstractions.Services;
using Ristorante.Models.Entities;
using Ristorante.Models.Repository;

namespace Ristorante.Application.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;

        public UtenteService(UtenteRepository utenteRepository)
        {
            _utenteRepository = utenteRepository;
        }

        public void addUtente(Utente utente)
        {
            _utenteRepository.Aggiungi(utente);
            _utenteRepository.Save();
        }

        public List<Utente> getUtenti()
        {
            return new List<Utente>();
        }

        public List<Utente> getUtenti(int from, int num, out int totalNum, int? idUtente)
        {
            return _utenteRepository.getUtenti(from, num, out totalNum, idUtente);   
        }
    }
}
