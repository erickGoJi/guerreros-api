using biz.guerreros.Models.SupportProgramsDetail;
using biz.guerreros.Repository.SupportPrograms;
using biz.guerreros.Repository.SupportProgramsDetail;
using dal.guerreros.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.guerreros.Repository.SupportProgramsDetail
{
    public class SupportProgramsDetailRepository : GenericRepository<biz.guerreros.Entities.SupportProgramsDetail>, ISupportProgramsDetail
    {
        public SupportProgramsDetailRepository(Db_GuerrerosContext context) : base(context) { }
        public SupportProgramsDetailService GetSupportProgramDetail(int SupportProgram)
        {
            var service = _context.SupportProgramsDetail
                .Where(a => a.SupportProgramsId == SupportProgram)
                .Select(b => new SupportProgramsDetailService
                {
                    Active = b.Active,
                    AgeRange = b.AgeRange,
                    Description = b.Description,
                    Id = b.Id,
                    mainIntervention = b.MainIntervention,
                    PublicationDate = b.PublicationDate,
                    RegistrationDate = b.RegistrationDate,
                    StudyTypeId = b.StudyTypeId,
                    SupportProgramsId = b.SupportProgramsId,
                    approved = b.SupportPrograms.Approved == true ? 1 : 0,
                    programContent = b.SupportPrograms.ProgramContent,
                    programTitle = b.SupportPrograms.ProgramTitle,
                    summary = b.SupportPrograms.Summary,
                    studyCategoryId = b.SupportPrograms.StudyCategoryId


                }).FirstOrDefault();

            return service;
        }
    }
}
