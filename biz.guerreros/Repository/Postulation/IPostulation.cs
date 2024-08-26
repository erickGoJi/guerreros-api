using biz.guerreros.Models.dashboard;
using biz.guerreros.Models.Postulation;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.Postulation
{
    public interface IPostulation:IGenericRepository<biz.guerreros.Entities.Postulation>
    {
        List<postulationService> GetPostulationByDoctorId(int doctorId);

        postulationService GetPostulationDetail(int postulationId);

        List<postulacionesEncabezadoService> GetEncabezadoPostulaciones(string fechaInicial, string FechaFinal, int idMedico, string idPaciente);

        List<ddlPostulacion> GetDDLPostulacion();

        postulacionesEncabezadoService GetDetallePostulacionBacoffice(int postulationId);
    }
}
