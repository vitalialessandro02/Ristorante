using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ristorante.Models.Entities;

namespace Ristorante.Application.Abstractions.Services
{
    public interface IUtenteService
    {
        List<Utente> GetUtenti();

        List<Utente> GetUtenti(int from, int num, out int totalNum, int? idUtente);

        void AddUtente(Utente utente);

    }
}
