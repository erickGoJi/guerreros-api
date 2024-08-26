using biz.guerreros.Entities;
using biz.guerreros.Models.dashboard;
using biz.guerreros.Models.StudiClinicians;
using biz.guerreros.Repository.StudiesClinicians;
using dal.guerreros.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.guerreros.Repository.StudiesClinicians
{
   public  class StudiesCliniciansRepository:GenericRepository<biz.guerreros.Entities.StudiesClinicians>,IStudiesClinicians
    {
        public StudiesCliniciansRepository(Db_GuerrerosContext context) : base(context) { }



        public List<StudiCliniciansService> GetAllNewsStudiesClinicians()
        {
            var service = _context.StudiesClinicians
                .Where(j => j.Approved == true)
                .Select(i => new StudiCliniciansService
                {
                    Id = i.Id,
                    StudyCategoryId = i.StudyCategoryId,
                    SatatusId = i.SatatusId,
                    Title = i.Title,
                    StudyContent = i.StudyContent,
                    PublicationDate = i.PublicationDate,
                    aprobado = i.Approved


                }).ToList();

            return service;
        }

        public List<encabezadoEnsayosClinicos> GetEncabezadoEnsayosClinicos(string fechaInicial, string FechaFinal, int statusId, int categoriaId)
        {
            var servie = _context.StudiesClinicians
                //.Where(l => l.Approved == true)
                .Where(b => b.PublicationDate.Date >= Convert.ToDateTime(fechaInicial).Date && b.PublicationDate.Date <= Convert.ToDateTime(FechaFinal).Date)
                .Where(k => statusId == 0 || k.SatatusId == statusId)
                .Where(k => categoriaId == 0 || k.StudyCategoryId == categoriaId)
                .Select(i => new encabezadoEnsayosClinicos
                {

                    ensayoClinicoId = i.Id,
                    categoria = i.StudyCategory.Name,
                    estatus = i.Satatus.Name,
                    fechaPublicacion = i.PublicationDate,
                    nombreEstudio = i.Title,
                    aprobado = i.Approved,
                    strAprobado = i.Approved == false ? "Inactivo":"Activo"





                }).ToList();

            return servie;
        }

        public List<encabezadoEnsayosClinicos> GetEncabezadoEnsayosClinicosSinAprobar(string fechaInicial, string FechaFinal, int statusId, int categoriaId)
        {

            var servie = _context.StudiesClinicians
                .Where(j => j.Approved == false)
                .Where(b => b.PublicationDate.Date >= Convert.ToDateTime(fechaInicial).Date && b.PublicationDate.Date <= Convert.ToDateTime(FechaFinal).Date)
                .Where(k => statusId == 0 || k.SatatusId == statusId)
                .Where(k => categoriaId == 0 || k.StudyCategoryId == categoriaId)
                .Select(i => new encabezadoEnsayosClinicos
                {

                    ensayoClinicoId = i.Id,
                    categoria = i.StudyCategory.Name,
                    estatus = i.Satatus.Name,
                    fechaPublicacion = i.PublicationDate,
                    nombreEstudio = i.Title,
                    aprobado = i.Approved





                }).ToList();

            return servie;

        }

        public estudiosClinicosService GetEstudioClinicoById(int CliniciansStudyId)
        {
            var service = _context.StudiesClinicians
                .Where(x => x.Id == CliniciansStudyId)
                .Select(i => new estudiosClinicosService
                {
                    Id = i.Id,
                    AgeRange = i.ClinicalStudy.Select(x => x.AgeRangeNavigation.AgeRange).FirstOrDefault(),
                    Approved = i.Approved,
                    Description = i.ClinicalStudy.Select(x => x.Description).FirstOrDefault(),
                    MainIntervention = i.ClinicalStudy.Select(x => x.MainIntervention).FirstOrDefault(),
                    ProtocolNumber = i.ClinicalStudy.Select(x => x.ProtocolNumber).FirstOrDefault(),
                    PublicationDate = i.PublicationDate,
                    SatatusId = i.SatatusId,
                    StudyCategoryId = i.StudyCategoryId,
                    StudyContent = i.StudyContent,
                    StudyTypeId = i.ClinicalStudy.Select(x => x.StudyTypeId).FirstOrDefault(),
                    Title = i.Title,
                    Name = i.Name,
                    AgeRangeId = i.ClinicalStudy.Select(x => x.AgeRangeId).FirstOrDefault()
                }).FirstOrDefault();

            return service;
        }

        public List<Status> GetStatusEstudiosClinicos()
        {
            var service = _context.Status
                .Select(i => new Status
                {
                    Id = i.Id,
                    Name = i.Name


                }).ToList();

            return service;
        }

        public List<StudiCliniciansService> GetStudiesCliniciansByCategory(int CategoryId)
        {
            var service = _context.StudiesClinicians
                .Where(i => i.StudyCategoryId == CategoryId && i.Approved == true)
                    .Select(i => new StudiCliniciansService
                    {
                        Id = i.Id,
                        StudyCategoryId = i.StudyCategoryId,
                        SatatusId = i.SatatusId,
                        Title = i.Title,
                        StudyContent = i.StudyContent,
                        PublicationDate = i.PublicationDate,
                        aprobado = i.Approved

                    }).ToList();

            return service;


        }


        public List<StudiCliniciansService> GetStudiesCliniciansByCategoryText(string Category)
        {
            var service = _context.StudiesClinicians
                .Include(x => x.StudyCategory)
                .Where(e => e.StudyCategory.Name == Category && e.Approved == true)
                .Select(i => new StudiCliniciansService
                {
                    Id = i.Id,
                    StudyCategoryId = i.StudyCategoryId,
                    SatatusId = i.SatatusId,
                    Title = i.Title,
                    StudyContent = i.StudyContent,
                    PublicationDate = i.PublicationDate,
                    aprobado = i.Approved

                }).ToList();

            return service;
        }

        public List<StudiCliniciansService> GetStudiesCliniciansCategoryTextByTypeStudy(int Category,int typeStudy,int ageRange, string name)
        {
            var service = _context.StudiesClinicians
                .Include(x => x.StudyCategory)
                .Where(j => j.Approved == true)
                .Where(e => Category == 0 || e.StudyCategoryId == Category)
                .Where(j => typeStudy == 0 || j.ClinicalStudy.Any(i => i.StudyTypeId == typeStudy))
                .Where(k => ageRange == 0 || k.ClinicalStudy.Any(i => i.AgeRangeId == ageRange))
                .Where(x=> string.IsNullOrEmpty(name) || x.Name == name)
                .Select(i => new StudiCliniciansService
                {
                    Id = i.Id,
                    StudyCategoryId = i.StudyCategoryId,
                    SatatusId = i.SatatusId,
                    Title = i.Title,
                    StudyContent = i.StudyContent,
                    PublicationDate = i.PublicationDate,
                    aprobado = i.Approved

                }).ToList();

            return service;

        }
    }
}
