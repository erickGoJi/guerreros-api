using biz.guerreros.Models.ContactGuerreros;
using biz.guerreros.Repository.ContactGuerreros;
using dal.guerreros.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.guerreros.Repository.ContactGuerreros
{
    public class contactGuerrerosRepository : GenericRepository<biz.guerreros.Entities.ContactGuerreros>, IcontactGuerreros
    {
        public contactGuerrerosRepository(Db_GuerrerosContext context) : base(context) { }
        public contactGuerrerosService GetContactGuerreros()
        {
            var service = _context.ContactGuerreros
                .Select(i => new contactGuerrerosService
                {
                    Id = i.Id,
                    Description = i.Description,
                    Email = i.Email,
                    Facebook = i.Facebook,
                    Instagram = i.Instagram,
                    Phone = i.Phone,
                    RegistrationDate = i.RegistrationDate,
                    Title = i.Title,
                    twitter = i.Twitter
                }).FirstOrDefault();

            return service;

        }
    }
}
