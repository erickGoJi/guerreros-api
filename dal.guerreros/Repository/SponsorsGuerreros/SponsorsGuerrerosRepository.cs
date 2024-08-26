using biz.guerreros.Models.SponsorsGuerreros;
using biz.guerreros.Repository.SponsorsGuerreros;
using dal.guerreros.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.guerreros.Repository.SponsorsGuerreros
{
    public class SponsorsGuerrerosRepository : GenericRepository<biz.guerreros.Entities.SponsorsGuerreros>, ISponsorsGuerreros
    {
        public SponsorsGuerrerosRepository(Db_GuerrerosContext context) : base(context) { }
        public SponsorsGuerrerosService GetSponsorsGuerreros()
        {
            var service = _context.SponsorsGuerreros
                .Select(i => new SponsorsGuerrerosService
                {
                     Id = i.Id,
                     Description = i.Description,
                     Title = i.Title,
                     RegistrationDate = i.RegistrationDate

                }).FirstOrDefault();

            return service;
        }
    }
}
