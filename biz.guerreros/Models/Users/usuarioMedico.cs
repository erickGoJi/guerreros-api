using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.Users
{
    public class usuarioMedico
    {
        public int userId { get; set; }

        public string nombre { get; set; }

        public string especialidad { get; set; }

        public int especialidadId { get; set; }

        public string cedula { get; set; }

        public string correo { get; set; }

        public string avatar { get; set; }

        public DateTime? fechaRegistro { get; set; }

        public bool? verificado { get; set; }

    }
}
