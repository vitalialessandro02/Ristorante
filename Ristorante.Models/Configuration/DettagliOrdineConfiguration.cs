using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ristorante.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Models.Configuration
{
    public class DettagliOrdineConfiguration
    {
        public void Configure(EntityTypeBuilder<DettagliOrdine> builder)
        {
            builder.ToTable("DettagliOrdine");
            builder.Property(p => p.IdOrdine);


            builder.Property(p => p.IdPortata);
            builder.Property(p => p.Quantita);

        }
    }
}
