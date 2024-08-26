using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.dashboard
{
    public class ListaMedicosPostulaciones
    {
        public int IdMedico { get; set; }

        public string nombreMedico { get; set; }

        public string nombreEstudioClinico { get; set; }

        public int numeroPostulaciones { get; set; }

        public DateTime? fechaRegistroMedico { get; set; }
    }
}
