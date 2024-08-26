﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;



namespace biz.guerreros.Entities
{
    public partial class StudiesClinicians
    {
        public StudiesClinicians()
        {
            ClinicalStudy = new HashSet<ClinicalStudy>();
            InclusionCriteria = new HashSet<InclusionCriteria>();
            Postulation = new HashSet<Postulation>();
            ShareClinicalStudies = new HashSet<ShareClinicalStudies>();
        }

        public int Id { get; set; }
        public int StudyCategoryId { get; set; }
        public int SatatusId { get; set; }
        public string Title { get; set; }
        public string StudyContent { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool? Approved { get; set; }

        public virtual Status Satatus { get; set; }
        public virtual StudyCategory StudyCategory { get; set; }
        public virtual ICollection<ClinicalStudy> ClinicalStudy { get; set; }
        public virtual ICollection<InclusionCriteria> InclusionCriteria { get; set; }
        public virtual ICollection<Postulation> Postulation { get; set; }
        public virtual ICollection<ShareClinicalStudies> ShareClinicalStudies { get; set; }
    }
}