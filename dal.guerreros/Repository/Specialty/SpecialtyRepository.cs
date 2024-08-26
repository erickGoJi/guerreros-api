using biz.guerreros.Models.Specialty;
using biz.guerreros.Repository.Specialty;
using dal.guerreros.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.guerreros.Repository.Specialty
{
    public class SpecialtyRepository : GenericRepository<biz.guerreros.Entities.Specialty>, ISpecialty
    {

        public SpecialtyRepository(Db_GuerrerosContext context) : base(context) { }
        public List<SpecialtyService> GetAllSpecialty()
        {
            var service = _context.Specialty
                .Select(i => new SpecialtyService
                {
                    Id = i.Id,
                    Name = i.Name
                }
                ).ToList();

            return service;
        }
    }
}
