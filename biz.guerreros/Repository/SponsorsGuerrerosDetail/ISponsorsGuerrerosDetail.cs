using biz.guerreros.Models.SponsorsGuerrerosDetail;
using biz.guerreros.Models.SupportProgramsDetail;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.SponsorsGuerrerosDetail
{
    public interface ISponsorsGuerrerosDetail:IGenericRepository<biz.guerreros.Entities.SponsorsGuerrerosDetail>
    {
        List<SponsorsGuerrerosDetailService> GetSponsorsGuerrerosDetail();
        List<SponsorsGuerrerosDetailService> GetSponsorsGuerrerosDetailColaboradores();
    }
}
