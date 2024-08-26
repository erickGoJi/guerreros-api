using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.SponsorsGuerrerosDetail
{
    public class SponsorsGuerrerosDetailService
    {
        public int Id { get; set; }
        public int SponsorGuerrerosId { get; set; }

        public string ImageSponsor { get; set; }

        public string Description { get; set; }
    }
}
