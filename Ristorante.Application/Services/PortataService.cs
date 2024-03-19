using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ristorante.Application.Abstractions.Services;
using Ristorante.Models.Entities;
using Ristorante.Models.Enumeration;
using Ristorante.Models.Repositories;

namespace Ristorante.Application.Services
{
    public class PortataService : IPortataService
    {
        private readonly PortataRepository _portataRepository;
        public PortataService(PortataRepository portataRepository) 
        { 
            _portataRepository = portataRepository;
        }
        public List<Portata> GetPortate() { return new List<Portata>(); }
        public List<Portata> GetPortate(int from, int num, out int totalNum, Tipologia? tipologia)
        {
            return _portataRepository.GetPortate(from, num, out totalNum, tipologia);
        }
    }
}
