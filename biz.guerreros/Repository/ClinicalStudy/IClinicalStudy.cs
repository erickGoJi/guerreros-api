using biz.guerreros.Models;
using biz.guerreros.Models.AgeRange;
using biz.guerreros.Models.ClinicalStudy;
using biz.guerreros.Models.dashboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.ClinicalStudy
{
    public interface IClinicalStudy:IGenericRepository<biz.guerreros.Entities.ClinicalStudy>
    {
        ClinicalStudyService GetClinicalStudyDetail(int StudiesCliniciansId);

        List<ageRangeService> GetAllAgeRage();
        List<CatDiseases> GetAllDiseases();

        dashboard GetDashboardBackOffice();
    }
}
