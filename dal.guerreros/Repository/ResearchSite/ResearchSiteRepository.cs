using biz.guerreros.Models.ResearchSite;
using biz.guerreros.Repository.ResearchSite;
using dal.guerreros.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.guerreros.Repository.ResearchSite
{
    public class ResearchSiteRepository : GenericRepository<biz.guerreros.Entities.ResearchSites>, IResearchSite
    {

        public ResearchSiteRepository(Db_GuerrerosContext context) : base(context) { }

        public List<ResearchSiteService> GetAllResearchSite()
        {
            var service = _context.ResearchSites
                .Select(i => new ResearchSiteService
                {
                    Id = i.Id,
                    Name = i.Name
                }).ToList();

            return service;
        }
    }
}
