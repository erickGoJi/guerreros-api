using biz.guerreros.Models.Specialty;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.Specialty
{
    public interface ISpecialty:IGenericRepository<biz.guerreros.Entities.Specialty>
    {
        List<SpecialtyService> GetAllSpecialty();

    }
}
