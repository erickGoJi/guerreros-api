using biz.guerreros.Models.SupportPrograms;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.SupportPrograms
{
    public interface ISupportPrograms:IGenericRepository<biz.guerreros.Entities.SupportPrograms>
    {
        List<SupportProgramsService> GetSupportPrograms();

        List<SupportProgramsService> GetSupportProgramsByCategoryId(int CategoryId);

        List<SupportProgramsService> GetSupportProgramsByCategoryText(string category);

        List<SupportProgramsService> GetSupportProgramsByCategoryProgramTypeAgeRange(int category,int TypeProgram,int AgeRange, string name);

        List<SupportProgramsService> GetSupportProgramsBackOffice(string fechaInicial, string FechaFinal, int categoriaId);

    }
}
