using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure.Configurations
{
    public class RendezVousConfiguration : IEntityTypeConfiguration<RendezVous>
    {
        public void Configure(EntityTypeBuilder<RendezVous> builder)
        {
            //cle primaire composéé
            builder.HasKey(f => new
            {
f.CitoyenId,
f.VaccinId,
f.DateVaccin 
            });
            //clé etrangere

            builder.HasOne<Vaccin>(f=>f.Vaccin).WithMany(f=>f.RendezVouss).HasForeignKey(f=>f.VaccinId);

            //cle etrangere
            builder.HasOne<Citoyen>(f => f.Citoyen).WithMany(f => f.RendezVouss).HasForeignKey(f => f.CitoyenId);
        }
    }
}
