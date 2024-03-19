using Ristorante.Application.Abstractions.Services;
using Ristorante.Models.Entities;
using Ristorante.Models.Repositories;

namespace Ristorante.Application.Services
{
    public class DettaglioOrdineService : IDettaglioOrdineService
    {
        private readonly DettaglioOrdineRepository _dettaglioOrdineRepository;
        public DettaglioOrdineService(DettaglioOrdineRepository dettaglioOrdineRepository)
        {
            _dettaglioOrdineRepository = dettaglioOrdineRepository;
        }

        public List<DettagliOrdine> GetDettagliOrdineList() { return new List<DettagliOrdine>() ;}
        
        public List<DettagliOrdine> GetDettagliOrdine(int from, int num, out int totalNum, int? idPortata, int? idOrdine) 
        { 
            return _dettaglioOrdineRepository.GetDettagliOrdine(from,num,out totalNum,idPortata,idOrdine); 
        }

    }
}
