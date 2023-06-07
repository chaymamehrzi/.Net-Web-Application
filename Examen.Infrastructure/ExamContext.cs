using Examen.ApplicationCore.Domain;
using Examen.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure
{
    public class ExamContext:DbContext
    {

        public DbSet<Citoyen> citoyens { get; set; }
        public DbSet<Vaccin> vaccins { get; set; }
        public DbSet<RendezVous> rendezVous { get; set; }
        public DbSet<CentreVacincation> centreVaccinations { get; set; }


        //les dbsets
        public DbSet<Exemple> Exemples { get; set; }
        //....................
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=ExamenDB;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies(); //activer lazy loading
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RendezVousConfiguration());
            //...................
            //tpt 
            //tph => config

            modelBuilder.Entity<Citoyen>().OwnsOne(c => c.Addresse, ad =>
            {
                ad.Property(a => a.Rue);
                ad.Property(a => a.CodePostal);
                ad.Property(a => a.Ville);


            });
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }
    }
}
