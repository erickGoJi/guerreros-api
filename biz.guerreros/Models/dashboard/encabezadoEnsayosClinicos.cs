using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.dashboard
{
    public class encabezadoEnsayosClinicos
    {
        public int ensayoClinicoId { get; set; }

        public string categoria { get; set; }

        public string estatus { get; set; }

        public string nombreEstudio { get; set; }

        public DateTime fechaPublicacion { get; set; }

        public bool? aprobado { get; set; }

        public string strAprobado { get; set; }
    }
}
