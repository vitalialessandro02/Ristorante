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
    public class UtentiConfiguration : IEntityTypeConfiguration<Utente>
    {

        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utenti");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Email)
                .HasMaxLength(50);
            builder.Property(p => p.Nome)
              .HasMaxLength(50);
            builder.Property(p => p.Cognome)
              .HasMaxLength(50);
            builder.Property(p => p.Password)
              .HasMaxLength(50);
            builder.Property(p => p.RuoloUtente)
                .HasColumnName("Ruolo")
                .HasConversion<int>();
        }
    }

   



}
