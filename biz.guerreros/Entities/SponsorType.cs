﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;



namespace biz.guerreros.Entities
{
    public partial class SponsorType
    {
        public SponsorType()
        {
            SponsorsGuerrerosDetail = new HashSet<SponsorsGuerrerosDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SponsorsGuerrerosDetail> SponsorsGuerrerosDetail { get; set; }
    }
}