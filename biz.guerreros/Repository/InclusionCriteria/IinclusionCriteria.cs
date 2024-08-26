using biz.guerreros.Models.InclusionCriteria;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.InclusionCriteria
{
    public interface IinclusionCriteria:IGenericRepository<biz.guerreros.Entities.InclusionCriteria>
    {
        List<inclusionCriteriaService> GetAllInclusionCriteria(int StudiesCliniciansId);
    }
}
