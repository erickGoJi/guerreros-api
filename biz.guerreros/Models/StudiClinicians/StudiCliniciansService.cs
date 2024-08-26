using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.StudiClinicians
{
    public class StudiCliniciansService
    {
        public int Id { get; set; }
        public int StudyCategoryId { get; set; }
        public int SatatusId { get; set; }
        public string Title { get; set; }
        public string StudyContent { get; set; }
        public DateTime PublicationDate { get; set; }

        public bool? aprobado { get; set; }
    }
}
