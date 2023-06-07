using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public enum TypeVaccin
    {
        PFizer,Moderna,Jhonson
    }
    public class Vaccin
    {

        [DataType(DataType.Date)]
        public  DateTime DateValidation { get; set; }
        public string Fournisseur { get; set; }
        public int Quantite { get; set; }


        public int VaccinId { get; set; }

        public TypeVaccin TypeVaccin { get; set; }

        public  int? CentreVacinationId { get; set; }

        [ForeignKey("CentreVacinationId")]
        public virtual CentreVacincation Centrevaccination { get; set; } 

        public virtual IList<RendezVous> RendezVouss { get; set; } 

 






    }
}
