using biz.guerreros.Models.ResearchSite;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.ResearchSite
{
    public interface IResearchSite:IGenericRepository<biz.guerreros.Entities.ResearchSites>
    {
        List<ResearchSiteService> GetAllResearchSite();
    }
}
