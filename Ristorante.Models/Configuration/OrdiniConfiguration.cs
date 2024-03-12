using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ristorante.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ristorante.Models.Configuration
{
    public class OrdiniConfiguration
    {
        public void Configure(EntityTypeBuilder<Ordine> builder)
        {
            builder.ToTable("Ordine");
            builder.HasKey(p => p.NumeroOrdine);
            builder.Property(p => p.IdUtente);

            
            builder.Property(p => p.DataOrdine);
            builder.Property(p => p.Indirizzo)
              .HasMaxLength(50);

            builder.HasOne(x => x.UtenteCheOrdina)
            .WithMany(x => x.Ordini)
            .HasForeignKey(x => x.IdUtente);

        }


    }
}
