using biz.guerreros.Models.SupportPrograms;
using biz.guerreros.Repository.SupportPrograms;
using dal.guerreros.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.guerreros.Repository.SupportPrograms
{
    public class SupportProgramsRepository : GenericRepository<biz.guerreros.Entities.SupportPrograms>, ISupportPrograms
    {

        public SupportProgramsRepository(Db_GuerrerosContext context) : base(context) { }
        public List<SupportProgramsService> GetSupportPrograms()
        {
            var service = _context.SupportPrograms
                .Select(i => new SupportProgramsService
                {
                    Id = i.Id,
                    Active = i.Active,
                    ProgramContent = i.ProgramContent,
                    ProgramTitle = i.ProgramTitle,
                    PublicationDate = i.PublicationDate,
                    StudyCategoryId = i.StudyCategoryId,
                    summary = i.Summary,
                    categoria = i.StudyCategory.Name,
                    Status = i.Active == true ? "Activo" : "Inactivo"

                }).ToList();

            return service;
        }

        public List<SupportProgramsService> GetSupportProgramsBackOffice(string fechaInicial, string FechaFinal, int categoriaId)
        {
            var service = _context.SupportPrograms
                .Where(b => b.PublicationDate.Date >= Convert.ToDateTime(fechaInicial).Date && b.PublicationDate.Date <= Convert.ToDateTime(FechaFinal).Date)
                .Where(k => categoriaId == 0 || k.StudyCategoryId == categoriaId)
                .Select(i => new SupportProgramsService
                {
                    Id = i.Id,
                    Active = i.Active,
                    ProgramContent = i.ProgramContent,
                    ProgramTitle = i.ProgramTitle,
                    PublicationDate = i.PublicationDate,
                    StudyCategoryId = i.StudyCategoryId,
                    summary = i.Summary,
                    categoria = i.StudyCategory.Name,
                    Status = i.Active == true ? "Activo" : "Inactivo"

                }).ToList();

            return service;
        }

        public List<SupportProgramsService> GetSupportProgramsByCategoryId(int CategoryId)
        {
            var service = _context.SupportPrograms
                .Where(j => j.StudyCategoryId == CategoryId)
                .Select(i => new SupportProgramsService
                {
                    Id = i.Id,
                    Active = i.Active,
                    ProgramContent = i.ProgramContent,
                    ProgramTitle = i.ProgramTitle,
                    PublicationDate = i.PublicationDate,
                    StudyCategoryId = i.StudyCategoryId,
                    summary = i.Summary

                }).ToList();

            return service;
        }

        public List<SupportProgramsService> GetSupportProgramsByCategoryProgramTypeAgeRange(int category, int TypeProgram, int AgeRange, string name)
        {
            var service = _context.SupportPrograms
               .Include(x => x.StudyCategory)
               .ThenInclude(i=>i.StudiesClinicians)
               .Include(y => y.SupportProgramsDetail)
               .Where(a => category == 0 || a.StudyCategoryId == category)
               //.Where(b => TypeProgram == 0 || b.SupportProgramsDetails. == TypeProgram)
               .Where(c =>AgeRange == 0 || c.SupportProgramsDetail.Any(a=> a.AgeRangeId.Value.Equals(AgeRange)))
               .Where(c => string.IsNullOrEmpty(name) || c.StudyCategory.StudiesClinicians.Any(a=>a.Name.Equals(name)))
               .Select(i => new SupportProgramsService
               {
                   Id = i.Id,
                   Active = i.Active,
                   ProgramContent = i.ProgramContent,
                   ProgramTitle = i.ProgramTitle,
                   PublicationDate = i.PublicationDate,
                   StudyCategoryId = i.StudyCategoryId,
                   summary = i.Summary

               }).ToList();

            return service;

        }

        public List<SupportProgramsService> GetSupportProgramsByCategoryText(string category)
        {
            var service = _context.SupportPrograms
                .Include(x => x.StudyCategory)
                .Where(j => j.StudyCategory.Name == category)
                .Select(i => new SupportProgramsService
                {
                    Id = i.Id,
                    Active = i.Active,
                    ProgramContent = i.ProgramContent,
                    ProgramTitle = i.ProgramTitle,
                    PublicationDate = i.PublicationDate,
                    StudyCategoryId = i.StudyCategoryId,
                    summary = i.Summary

                }).ToList();

            return service;
        }
    }
}
