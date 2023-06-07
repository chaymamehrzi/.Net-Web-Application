using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{

   
  public class Citoyen
    {

        public int age { get; set; }

        [Key]
        public string CIN { get; set; }

        public int CitoyenId { get; set; }

        public string Nom { get; set; }
        [Required]
        public int NumeroEvax { get; set; }

        public string Prenom { get; set; }

        public int Telephone { get; set; }

        public Addresse Addresse { get; set; }


        public virtual IList<RendezVous> RendezVouss { get; set; }





    }
}
