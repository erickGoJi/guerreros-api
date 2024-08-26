using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.SupportPrograms
{
    public class SupportProgramsService
    {
        public int Id { get; set; }

        public int StudyCategoryId { get; set; }

        public string ProgramTitle { get; set; }

        public string ProgramContent { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool Active { get; set; }

        public string summary { get; set; }

        public string categoria { get; set; }

        public string Status { get; set; }



    }
}
