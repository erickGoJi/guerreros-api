using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.dashboard
{
    public class dashboard
    {
        public int totalPostulaciones { get; set; }

        public int totalMedicos { get; set; }

        public int totalMedicosRegistradosNes { get; set; }

        public int TotalEstudiosCompartidos { get; set; }

        public List<postulacionEstudioClinico> postulacionesPorEstudioClinico { get; set; }

        public List<postulacionEstudioClinico> CompartidosPorEstudioClinico { get; set; }

        public List<postulacionesMedico> PostulacionesPorMedico { get; set; }


        public List<ListaMedicosPostulaciones> listaMedicosPostulaciones { get; set; }
    }
}
