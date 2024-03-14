using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Application.Models.Requests
{
    public class CreateTokenRequest
    {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
   


}

