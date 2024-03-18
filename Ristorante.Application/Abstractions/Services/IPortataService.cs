using Ristorante.Models.Entities;
using Ristorante.Models.Enumeration;

namespace Ristorante.Application.Abstractions.Services
{
    public interface IPortataService
    {
        List<Portata> GetPortate();
        List<Portata> getPortate(int from, int num, out int totalNum,  Tipologia? tipologia);
    }
}
