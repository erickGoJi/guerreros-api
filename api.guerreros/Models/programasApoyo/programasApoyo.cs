using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.guerreros.Models.programasApoyo
{
    public class programasApoyo
    {
        public int Id { get; set; }
        public int StudyCategoryId { get; set; }
        public string ProgramTitle { get; set; }
        public string ProgramContent { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool Active { get; set; }
        public string Summary { get; set; }
        public bool? Approved { get; set; }

        public int? SupportProgramsId { get; set; }
        public string MainIntervention { get; set; }
        public string Description { get; set; }
        
        public DateTime RegistrationDate { get; set; }
        
        public int? StudyTypeId { get; set; }
        public string AgeRange { get; set; }


    }
}
