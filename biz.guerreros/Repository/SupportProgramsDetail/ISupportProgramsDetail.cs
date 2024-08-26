using biz.guerreros.Models.SupportProgramsDetail;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.SupportProgramsDetail
{
    public interface ISupportProgramsDetail:IGenericRepository<biz.guerreros.Entities.SupportProgramsDetail>
    {
        SupportProgramsDetailService GetSupportProgramDetail(int SupportProgram);
    }
}
