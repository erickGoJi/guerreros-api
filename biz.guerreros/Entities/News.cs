﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;



namespace biz.guerreros.Entities
{
    public partial class News
    {
        public int Id { get; set; }
        public int? StudyCategoryId { get; set; }
        public string Title { get; set; }
        public string ContentNews { get; set; }
        public string PathImage { get; set; }
        public DateTime DateNews { get; set; }

        public virtual StudyCategory StudyCategory { get; set; }
    }
}