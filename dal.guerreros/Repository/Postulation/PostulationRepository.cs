using biz.guerreros.Models.dashboard;
using biz.guerreros.Models.Postulation;
using biz.guerreros.Repository.Postulation;
using dal.guerreros.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.guerreros.Repository.Postulation
{
    public class PostulationRepository:GenericRepository<biz.guerreros.Entities.Postulation>,IPostulation
    {
        public PostulationRepository(Db_GuerrerosContext context) : base(context) { }

        public List<ddlPostulacion> GetDDLPostulacion()
        {
            var service = _context.Postulation
                .Select(i => new ddlPostulacion
                {
                    Id = i.Id,
                    codigoPaciente = i.PatientCode


                }).ToList();

            return service;

        }

        public postulacionesEncabezadoService GetDetallePostulacionBacoffice(int postulationId)
        {

            var service = _context.Postulation
                .Where(b => b.Id == postulationId)
                .Select(i => new postulacionesEncabezadoService
                {
                    id = i.Id,
                    pacienteId = i.PatientCode,
                    estatus = i.Active == true ? "Activo" : "Inactivo",
                    medico = i.User.Name,
                    fechaPostulacion = i.RegistrationDate,
                    tipoEstudio = i.StudiesClinicians.StudyCategory.Name,
                    estudioMedico = i.StudiesClinicians.StudyContent,
                    informacionRelevante = i.RelevantDate,
                    padecimiento = i.Suffering,
                    categoriaId = i.StudiesClinicians.StudyCategory.Id,
                    estudioMedicoId = i.StudiesCliniciansId,
                    email = i.Email,
                    telefono = i.Phone



                }).FirstOrDefault();

            return service;


        }

        public List<postulacionesEncabezadoService> GetEncabezadoPostulaciones(string fechaInicial, string FechaFinal, int idMedico, string idPaciente)
        {
            var service = _context.Postulation
                .Where(b => b.RegistrationDate.Date >= Convert.ToDateTime(fechaInicial).Date && b.RegistrationDate.Date <= Convert.ToDateTime(FechaFinal).Date)
                .Where(k => idMedico == 0 || k.UserId == idMedico)
                .Where(j => string.IsNullOrEmpty(idPaciente) || j.PatientCode == idPaciente)
                .Select(i => new postulacionesEncabezadoService
                {
                    id = i.Id,
                    pacienteId = i.PatientCode,
                    estatus = i.Active == true ? "Activo" : "Inactivo",
                    medico = i.User.Name,
                    fechaPostulacion = i.RegistrationDate,
                    tipoEstudio = i.StudiesClinicians.StudyCategory.Name
                
                    
                }).ToList();

            return service;
        }

        public List<postulationService> GetPostulationByDoctorId(int doctorId)
        {
            var service = _context.Postulation
                .Where(i => i.UserId == doctorId)
                .Select(i => new postulationService
                {
                    Id = i.Id,
                    Active = i.Active,
                    Email = i.Email,
                    Name = i.Name,
                    PatientCode = i.PatientCode,
                    Phone = i.Phone,
                    RegistrationDate = i.RegistrationDate,
                    RelevantDate = i.RelevantDate,
                    Suffering = i.RelevantDate,
                    UserId = i.UserId
                }).ToList();


            return service;
        }

        public postulationService GetPostulationDetail(int postulationId)
        {
            var service = _context.Postulation
                .Where(i => i.Id == postulationId)
                .Select(i => new postulationService
                {
                    Id = i.Id,
                    Active = i.Active,
                    Email = i.Email,
                    Name = i.Name,
                    PatientCode = i.PatientCode,
                    Phone = i.Phone,
                    RegistrationDate = i.RegistrationDate,
                    RelevantDate = i.RelevantDate,
                    Suffering = i.RelevantDate,
                    UserId = i.UserId
                }).FirstOrDefault();

            return service;
        }
    }
}
