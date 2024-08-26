using biz.guerreros.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.InclusionCriteria
{
    public class inclusionCriteriaService
    {
        public int Id { get; set; }
        public int StudiesCliniciansId { get; set; }
        public string CriteriaLong { get; set; }
        public string CriteriaSmall { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime RegistrationDate { get; set; }

        public bool validado { get; set; }
         
        
    }
}
