using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ristorante.Models.Entities;

namespace Ristorante.Application.Abstractions.Services
{
    public interface IOrdineService
    {
        List<Ordine> getOrdini();

        List<Ordine> getOrdini(int from, int num, out int totalNum, DateTime dataInizio, DateTime dataFine, int idUtente);

        void addOrdine(Ordine ordine, List<int> portate, List<int> quantita);

        double GetPrezzo();
        int GetNumeroOrdine();
    }
}
