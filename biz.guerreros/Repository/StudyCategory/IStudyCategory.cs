using biz.guerreros.Entities;
using biz.guerreros.Models.StudyCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.StudyCategory
{
    public interface IStudyCategory:IGenericRepository<biz.guerreros.Entities.StudyCategory>
    {
        List<studyCategoryService> GetAllStudyCategory();

    }
}
