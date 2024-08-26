using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using biz.guerreros.Models.StudyCategory;
using biz.guerreros.Repository.StudyCategory;
using dal.guerreros.DBContext;


namespace dal.guerreros.Repository.StudyCategory
{
    public class StudyCategoryRepository : GenericRepository<biz.guerreros.Entities.StudyCategory>, IStudyCategory
    {

        public StudyCategoryRepository(Db_GuerrerosContext context) : base(context) { }
        public List<studyCategoryService> GetAllStudyCategory()
        {


            var service = _context.StudyCategory
                .Select(i => new studyCategoryService
                {
                    Id= i.Id,
                    Name = i.Name,
                    PathImage = i.PathImage,
                    PathImageAvatar = i.PathImageAvatar,
                    IsActiveStudy = i.StudiesClinicians.Any(a=>a.Approved.Value.Equals(true)),
                    IsActiveProgram = i.SupportPrograms.Any()
                }).ToList();

            return service;
        }
    }
}
