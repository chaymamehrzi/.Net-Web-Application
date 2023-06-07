﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class CentreVacincation
    {

        public int Capacite { get; set; }

        public int CentreVacincationId { get; set; }

        public int NbrChaises { get; set; }
        public int NumTelephone { get; set; }

        public string ResponsableCentre { get; set; }

        public virtual IList<Vaccin> vaccins { get; set; }


    }


}
