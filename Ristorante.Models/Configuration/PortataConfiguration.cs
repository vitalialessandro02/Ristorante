﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ristorante.Models.Entities;
using Ristorante.Models.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Models.Configuration
{
    public class PortateConfiguration : IEntityTypeConfiguration<Portata>
    {
        public void Configure(EntityTypeBuilder<Portata> builder)
        {
            builder.ToTable("Portate");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .HasMaxLength(50);
            builder.Property(p => p.Prezzo);
            builder.Property(p => p.TipologiaPortata)
                .HasColumnName("Tipologia")
                .HasConversion<int>();



        }
    }
}
