using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class RendezVous
    {

        public string codeInfirmiere { get; set; }

        public DateTime DateVaccin { get; set; }

        public int NbreDoses { get; set; }

        public int VaccinId { get; set; } 

        public string CitoyenId { get; set; }


        [ForeignKey("CitoyenId")] 
        public virtual Citoyen Citoyen { get; set; } 
         
        public virtual Vaccin Vaccin { get; set; }




    }
}
