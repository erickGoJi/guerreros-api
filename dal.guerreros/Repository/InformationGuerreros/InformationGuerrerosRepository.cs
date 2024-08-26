using biz.guerreros.Models.InformationGuerreros;
using biz.guerreros.Repository.InformationGuerreros;
using dal.guerreros.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.guerreros.Repository.InformationGuerreros
{
    public class InformationGuerrerosRepository : GenericRepository<biz.guerreros.Entities.InformationGuerreros>, IinformationGuerreros
    {

        public InformationGuerrerosRepository(Db_GuerrerosContext context) : base(context) { }

        public informationGuerrerosService GetInformationGuerreros()
        {
            var service = _context.InformationGuerreros
                .Select(i => new informationGuerrerosService
                {
                    Id = i.Id,
                    about = i.About,
                    NoticePrivacy = i.NoticePrivacy,
                    RegistrationDate = i.RegistrationDate

                }).FirstOrDefault();

            return service;
        }
    }
}
