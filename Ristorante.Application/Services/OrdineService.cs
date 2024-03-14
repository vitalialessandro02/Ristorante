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
    public class OrdineService : IOrdineService
    {
        private readonly OrdineRepository _ordineRepository;
        private readonly DettaglioOrdineRepository _dettaglioOrdineRepository;

        public OrdineService(OrdineRepository ordineRepository, DettaglioOrdineRepository dettaglioOrdineRepository)
        {
            _ordineRepository = ordineRepository;
            _dettaglioOrdineRepository = dettaglioOrdineRepository;
        }

        public void addOrdine(Ordine ordine, Dictionary<Portata, int> portate)
        {
            _ordineRepository.Aggiungi(ordine);
            _ordineRepository.Save();
            var dettaglioOrdine = new DettagliOrdine();
            foreach(KeyValuePair<Portata,int> portata in portate)
            {
                dettaglioOrdine.IdPortata = portata.Key.Id;
                dettaglioOrdine.IdOrdine = ordine.IdOrdine;
                dettaglioOrdine.Quantita = portata.Value;
                _dettaglioOrdineRepository.Aggiungi(dettaglioOrdine);
                _dettaglioOrdineRepository.Save();
            }
        } 
        public List<Ordine> getOrdini()
        {
            return new List<Ordine>();
        }

        public List<Ordine> getOrdini(int from, int num, out int totalNum, DateTime dataInizio, DateTime dataFine, int idUtente)
        {
            return _ordineRepository.GetOrdine(from, num, out totalNum, dataInizio, dataFine, idUtente);
        }
    }
}
