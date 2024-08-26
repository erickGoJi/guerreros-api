using biz.guerreros.Models.StudyType;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.StudyType
{
    public interface IStudyType:IGenericRepository<biz.guerreros.Entities.StudyType>
    {
        List<StudyTypeServie> GetAllTypeStudy();
    }
}
