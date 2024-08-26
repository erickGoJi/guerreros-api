using biz.guerreros.Entities;
using biz.guerreros.Models.dashboard;
using biz.guerreros.Models.StudiClinicians;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.StudiesClinicians
{
    public interface IStudiesClinicians:IGenericRepository<biz.guerreros.Entities.StudiesClinicians>
    {
        List<StudiCliniciansService> GetAllNewsStudiesClinicians();

        List<StudiCliniciansService> GetStudiesCliniciansByCategory(int CategoryId);

        List<StudiCliniciansService> GetStudiesCliniciansByCategoryText(string Category);

        List<StudiCliniciansService> GetStudiesCliniciansCategoryTextByTypeStudy(int Category, int typeStudy, int ageRange, string name);


        List<encabezadoEnsayosClinicos> GetEncabezadoEnsayosClinicos(string fechaInicial, string FechaFinal, int statusId,int categoriaId);

        List<encabezadoEnsayosClinicos> GetEncabezadoEnsayosClinicosSinAprobar(string fechaInicial, string FechaFinal, int statusId, int categoriaId);

        List<Status> GetStatusEstudiosClinicos();

        estudiosClinicosService GetEstudioClinicoById(int CliniciansStudyId);

    }
}
