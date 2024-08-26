using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.Postulation
{
    public class postulationService
    {
        public int Id { get; set; }
        public string PatientCode { get; set; }

        public string Name { get; set; }
        public string Suffering { get; set; }
        public string RelevantDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int? UserId { get; set; }

        public bool? Active { get; set; }
    }
}
