﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;



namespace biz.guerreros.Entities
{
    public partial class Notifications
    {
        public int Id { get; set; }
        public int CliniciansStudiesId { get; set; }
        public string AgeRange { get; set; }
        public int StudyTypeId { get; set; }
        public string Token { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool ActiveNotifications { get; set; }
    }
}