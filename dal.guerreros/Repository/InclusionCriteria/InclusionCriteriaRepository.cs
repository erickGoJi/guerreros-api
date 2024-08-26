using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using biz.guerreros.Models.InclusionCriteria;
using biz.guerreros.Repository;
using biz.guerreros.Repository.InclusionCriteria;
using dal.guerreros.DBContext;

namespace dal.guerreros.Repository.InclusionCriteria
{
    public class InclusionCriteriaRepository : GenericRepository<biz.guerreros.Entities.InclusionCriteria>, IinclusionCriteria
    {
        public InclusionCriteriaRepository(Db_GuerrerosContext context) : base(context) { }
        public List<inclusionCriteriaService> GetAllInclusionCriteria(int StudiesCliniciansId)
        {
            var service = _context.InclusionCriteria
                .Where(j => j.StudiesCliniciansId == StudiesCliniciansId)
                .Select(i => new inclusionCriteriaService
                {
                    Id = i.Id,
                    Active = i.Active,
                    StudiesCliniciansId = i.StudiesCliniciansId,
                    CriteriaLong = i.CriteriaLong,
                    CriteriaSmall = i.CriteriaSmall,
                    Description = i.Description,
                    RegistrationDate = i.RegistrationDate,
                    validado = false



                }).ToList();

            return service;
                
        }

        
    }
}
