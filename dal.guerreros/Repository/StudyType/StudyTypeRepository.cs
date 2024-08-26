using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using biz.guerreros.Models.StudyType;
using biz.guerreros.Repository.StudyType;
using dal.guerreros.DBContext;

namespace dal.guerreros.Repository.StudyType
{
    public class StudyTypeRepository : GenericRepository<biz.guerreros.Entities.StudyType>, IStudyType
    {
        public StudyTypeRepository(Db_GuerrerosContext context) : base(context) { }
        public List<StudyTypeServie> GetAllTypeStudy()
        {
            var service = _context.StudyType
                    .Select(i => new StudyTypeServie
                    {
                        Id = i.Id,
                        Name = i.Name,
                        

                    }).ToList();

            return service;

        }
    }
}
