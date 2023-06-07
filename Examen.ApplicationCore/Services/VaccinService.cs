using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Examen.Interfaces;
using Examen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class VaccinService : Service<Vaccin>, IVaccinService
    {
        public VaccinService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {


        }

        public string Validité(Vaccin vaccin)
        {
            if (vaccin.Quantite >0 && vaccin.DateValidation >= DateTime.Now)
            {
                return "Valide";
            }
            else
            {
                return "Invalide";
            }
        }
    }
}
