using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.ClinicalStudy
{
    public class ClinicalStudyService
    {
        public int Id { get; set; }
        public int StudiesCliniciansId { get; set; }
        public string PublicationDate { get; set; }
        public string MainIntervention { get; set; }
        public string ProtocolNumber { get; set; }
        public string AgeRange { get; set; }
        public int? AgeRangeId { get; set; }
        public int? StudyTypeId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }

        public string StudyTypeDescription { get; set; }

    }
}
