using Ristorante.Models.Entities;

namespace Ristorante.Application.Abstractions.Services
{
    public interface IDettaglioOrdineService
    {
        List<DettagliOrdine> GetDettagliOrdineList();
        List<DettagliOrdine> GetDettagliOrdine(int from, int num, out int totalNum, int? idPortata, int? idOrdine);

    }
}
