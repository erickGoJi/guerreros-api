using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.StudiClinicians
{
    public class estudiosClinicosService
    {
        public int Id { get; set; }
        public int StudyCategoryId { get; set; }
        public int SatatusId { get; set; }
        public string Title { get; set; }
        public string StudyContent { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Name { get; set; }
        public string MainIntervention { get; set; }
        public string ProtocolNumber { get; set; }
        public string AgeRange { get; set; }
        public int? AgeRangeId { get; set; }
        public int? StudyTypeId { get; set; }
        public string Description { get; set; }

        public bool? Approved { get; set; }


    }
}
