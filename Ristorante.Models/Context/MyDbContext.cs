using Microsoft.EntityFrameworkCore;
using Ristorante.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ristorante.Models.Context
{
    public class MyDbContext : DbContext
    {

        public MyDbContext() : base()
        {
            
        }

        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config)
        {
            
        }

        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Ordine> Ordini { get; set; }
        public DbSet<Portata> Portate { get; set; }
        public DbSet<DettagliOrdine> DettagliOrdini { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               
               .UseSqlServer("data source=localhost;Initial catalog=Ristorante;User Id=ristorante;Password=ristorante;TrustServerCertificate=True");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
