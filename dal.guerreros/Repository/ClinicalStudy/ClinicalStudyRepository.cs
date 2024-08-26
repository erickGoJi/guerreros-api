using biz.guerreros.Entities;
using biz.guerreros.Models;
using biz.guerreros.Models.AgeRange;
using biz.guerreros.Models.ClinicalStudy;
using biz.guerreros.Models.dashboard;
using biz.guerreros.Repository.ClinicalStudy;
using dal.guerreros.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.guerreros.Repository.ClinicalStudy
{
    public class ClinicalStudyRepository : GenericRepository<biz.guerreros.Entities.ClinicalStudy>, IClinicalStudy
    {
        public ClinicalStudyRepository(Db_GuerrerosContext context) : base(context) { }

        public  List<ageRangeService> GetAllAgeRage()
        {
            int incremento = 0;
            //var service = _context.ClinicalStudies
            //    .GroupBy(g => g.AgeRange)
            //    .Select(y => new ageRangeService
            //    {
            //       Id = row + 1,
            //       AgeRange = y.AgeRange

            //    }).ToList();

            //return service;

            //var service = _context.ClinicalStudies
            //    //.GroupBy(x => x.AgeRange)
            //    .Select(i => new ageRangeService
            //    {
            //        Id = i.Id,
            //        AgeRange = i.AgeRange
            //    }).ToList();

            //var serviceEnd = service.Select(x => x new(ageRangeService{ })).GroupBy(s => s.AgeRange).ToList();

            var service = (from a in _context.ClinicalStudy
                          group a by new { a.AgeRange } into g
                          select new ageRangeService
                              {
                              Id = incremento + 1,
                              AgeRange = g.Key.AgeRange
                          }).ToList();
            var ageRanges = _context.CatAgeRange.Select(s=>  new ageRangeService
            {
                Id = s.Id,
                AgeRange = s.AgeRange
            }).ToList();

            return ageRanges;
        }

        public List<CatDiseases> GetAllDiseases()
        {
            var diseases = (from a in _context.StudiesClinicians
                           group a by new { a.Name } into g
                           select new CatDiseases
                           {
                               Name = g.Key.Name
                           }).ToList();
            return diseases;
        }

        public ClinicalStudyService GetClinicalStudyDetail(int StudiesCliniciansId)
        {
            var service = _context.ClinicalStudy
                .Include(x => x.StudiesClinicians)
                .Where(i => i.StudiesCliniciansId == StudiesCliniciansId)
                .Select(e => new ClinicalStudyService
                {
                    Id = e.Id,
                    StudiesCliniciansId = e.StudiesCliniciansId,
                    PublicationDate = e.PublicationDate.ToString("dddd, dd MMMM yyyy"),
                    MainIntervention = e.MainIntervention,
                    ProtocolNumber = e.ProtocolNumber,
                    AgeRange = e.AgeRangeNavigation.AgeRange,
                    StudyTypeId = e.StudyTypeId,
                    Description = e.Description,
                    StudyTypeDescription = e.StudyType.Name,
                    AgeRangeId = e.AgeRangeId,
                    Title = e.StudiesClinicians.Title,
                    Name = e.StudiesClinicians.Name
                }).FirstOrDefault();

            return service;
        }

        public dashboard GetDashboardBackOffice()
        {
            dashboard serviceResponse = new dashboard();

            serviceResponse.totalPostulaciones = _context.Postulation.Count();

            serviceResponse.totalMedicos = _context.Users.Count();

            serviceResponse.totalMedicosRegistradosNes = _context.Users
                .Where(i => i.CreatedDate.Value.Month == DateTime.Now.Month)
                .Select(i => new biz.guerreros.Entities.Users
                {
                    Id = i.Id


                }).ToList().Count();


            serviceResponse.TotalEstudiosCompartidos = _context.ShareClinicalStudies.Count();

            serviceResponse.postulacionesPorEstudioClinico = _context.StudiesClinicians
                .Select(i => new postulacionEstudioClinico
                {
                     estudioId = i.Id,
                     nombreEstudio = i.Title,
                     numeroPostulaciones = i.Postulation.Count()



                }).ToList();


            serviceResponse.CompartidosPorEstudioClinico = _context.StudiesClinicians
                .Select(i => new postulacionEstudioClinico
                {
                    estudioId = i.Id,
                    nombreEstudio = i.Title,
                    numeroPostulaciones = i.ShareClinicalStudies.Count()



                }).ToList();


            serviceResponse.PostulacionesPorMedico = _context.Users
                .Select(i => new postulacionesMedico
                {
                    postulacionId = i.Id,
                    nombreMedico = i.Name,
                     numeroPosulaciones = i.Postulation.Count()



                }).ToList();

            var service = _context.Postulation
                .Select(i => new ListaMedicosPostulaciones
                {
                      IdMedico = i.User.Id,
                       nombreMedico = i.User.Name,
                       nombreEstudioClinico = i.StudiesClinicians.Title,
                        numeroPostulaciones = (from p in _context.Postulation
                                              where p.UserId == i.User.Id
                                              select p).Count(),
                         fechaRegistroMedico = i.User.CreatedDate



                }).ToList();

            serviceResponse.listaMedicosPostulaciones = service.GroupBy(i => i.IdMedico).Select(y => y.First()).ToList();


            return serviceResponse;

        }
    }
}
