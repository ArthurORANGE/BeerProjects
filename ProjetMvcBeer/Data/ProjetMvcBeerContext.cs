using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetMvcBeer.Models;

namespace ProjetMvcBeer.Data
{
    public class ProjetMvcBeerContext : DbContext
    {
        public ProjetMvcBeerContext(DbContextOptions<ProjetMvcBeerContext> options)
            : base(options)
        {
        }
        public DbSet<Beer> Beer { get; set; }
        public DbSet<Devis> Devis { get; set; }
        public DbSet<MonCompte> MonCompte { get; set; }
        public DbSet<LigneDeVieDevis> LigneDeVieDevis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>().ToTable("Beer");
            modelBuilder.Entity<Devis>().ToTable("Devis");
            modelBuilder.Entity<MonCompte>().ToTable("MonCompte");
            modelBuilder.Entity<LigneDeVieDevis>().ToTable("LigneDeVieDevis");
        }



    }

}
