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
    public class ClitoyenServicecs : Service<Citoyen>, ICitoyenService
    {
        public ClitoyenServicecs(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IGrouping<string, IEnumerable<Citoyen>> getCityoyensVacines()
        {
            return (IGrouping<string, IEnumerable<Citoyen>>)GetMany(c => c.RendezVouss.Count > 0).GroupBy(c => c.Addresse.Ville);
        }
    }
}
