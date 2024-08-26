using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.SupportProgramsDetail
{
    public class SupportProgramsDetailService
    {
        public int Id { get; set; }

        public int? SupportProgramsId { get; set; }
        public string mainIntervention { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }

        public int? StudyTypeId { get; set; }
        public string AgeRange { get; set; }

        public string programTitle { get; set; }

        public string programContent { get; set; }

        public string summary { get; set; }

        public int approved { get; set; }

        public int studyCategoryId { get; set; }


    }
}
