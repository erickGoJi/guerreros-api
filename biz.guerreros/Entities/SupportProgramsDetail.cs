﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;



namespace biz.guerreros.Entities
{
    public partial class SupportProgramsDetail
    {
        public int Id { get; set; }
        public int? SupportProgramsId { get; set; }
        public string MainIntervention { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }
        public int? StudyTypeId { get; set; }
        public string AgeRange { get; set; }

        public virtual SupportPrograms SupportPrograms { get; set; }
    }
}