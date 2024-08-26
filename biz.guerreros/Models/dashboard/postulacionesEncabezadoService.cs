using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.dashboard
{
    public class postulacionesEncabezadoService
    {
        public int id { get; set; }
        public string pacienteId { get; set; }

        public DateTime fechaPostulacion { get; set; }

        public string estatus { get; set; }

        public string medico { get; set; }

        public string tipoEstudio { get; set; }

        public string padecimiento { get; set; }

        public string informacionRelevante { get; set; }

        public string estudioMedico { get; set; }

        public int? estudioMedicoId { get; set; }

        public int categoriaId { get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

    }
}
