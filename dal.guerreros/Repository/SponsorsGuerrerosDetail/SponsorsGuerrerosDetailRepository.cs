using biz.guerreros.Models.SponsorsGuerrerosDetail;
using biz.guerreros.Models.SupportProgramsDetail;
using biz.guerreros.Repository.SponsorsGuerrerosDetail;
using dal.guerreros.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.guerreros.Repository.SponsorsGuerrerosDetail
{
    public class SponsorsGuerrerosDetailRepository : GenericRepository<biz.guerreros.Entities.SponsorsGuerrerosDetail>, ISponsorsGuerrerosDetail
    {
        public SponsorsGuerrerosDetailRepository(Db_GuerrerosContext context) : base(context) { }
        public List<SponsorsGuerrerosDetailService> GetSponsorsGuerrerosDetail()
        {
            var service = _context.SponsorsGuerrerosDetail
                .Where(j => j.SponsorTypeId == 1) //Patrocinadores
                .Select(i => new SponsorsGuerrerosDetailService
                {
                    Id = i.Id,
                    ImageSponsor = i.ImageSponsor,
                    SponsorGuerrerosId = i.SponsorGuerrerosId,
                    Description = i.Description

                }).ToList();

            return service;
        }

        public List<SponsorsGuerrerosDetailService> GetSponsorsGuerrerosDetailColaboradores()
        {
            var service = _context.SponsorsGuerrerosDetail
                .Where(j => j.SponsorTypeId == 2) //Colaboradores
                .Select(i => new SponsorsGuerrerosDetailService
                {
                    Id = i.Id,
                    ImageSponsor = i.ImageSponsor,
                    SponsorGuerrerosId = i.SponsorGuerrerosId,
                    Description = i.Description

                }).ToList();

            return service;

        }
    }
}
