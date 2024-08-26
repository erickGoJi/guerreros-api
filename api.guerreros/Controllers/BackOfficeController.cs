using api.guerreros.Models;
using api.guerreros.Models.estudiosClinicos;
using api.guerreros.Models.programasApoyo;
using api.guerreros.Models.shareStudies;
using biz.guerreros.Entities;
using biz.guerreros.Models.dashboard;
using biz.guerreros.Models.Postulation;
using biz.guerreros.Models.StudiClinicians;
using biz.guerreros.Models.SupportPrograms;
using biz.guerreros.Models.SupportProgramsDetail;
using biz.guerreros.Models.Users;
using biz.guerreros.Repository;
using biz.guerreros.Repository.ClinicalStudy;
using biz.guerreros.Repository.InclusionCriteria;
using biz.guerreros.Repository.News;
using biz.guerreros.Repository.Postulation;
using biz.guerreros.Repository.ShareClinicalStudies;
using biz.guerreros.Repository.StudiesClinicians;
using biz.guerreros.Repository.SupportPrograms;
using biz.guerreros.Repository.SupportProgramsDetail;
using biz.guerreros.Servicies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace api.guerreros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackOfficeController : ControllerBase
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IShareClinicalStudies _shareStudies;
        private readonly IClinicalStudy _cliniclStudy;
        private readonly IPostulation _postulaciones;
        private readonly IStudiesClinicians _studiesClinicals;
        private readonly ISupportPrograms _programas;
        private readonly ISupportProgramsDetail _programasDetalle;
        private readonly INews _newsRepository;
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly IUserRepository _userRepository;
        private readonly IinclusionCriteria _inclusionCriterios;
        private readonly ISupportPrograms _supportPrograms;
        private readonly ISupportProgramsDetail _supportProgramsDetail;
        public BackOfficeController(AutoMapper.IMapper mapper,
        ILoggerManager logger,
        IShareClinicalStudies shareStudies,
        IClinicalStudy clinicalStudy,
        IPostulation postulaciones,
        IStudiesClinicians studiesClinicals,
        ISupportPrograms programas,
        ISupportProgramsDetail programasDetalle,
        INews newsRepository,
        IWebHostEnvironment hostingEnv,
        IUserRepository userRepository,
        IinclusionCriteria inclusionCriterios,
        ISupportPrograms supportPrograms,
        ISupportProgramsDetail supportProgramsDetail)
        {
            _mapper = mapper;
            _logger = logger;
            _shareStudies = shareStudies;
            _cliniclStudy = clinicalStudy;
            _postulaciones = postulaciones;
            _studiesClinicals = studiesClinicals;
            _programas = programas;
            _programasDetalle = programasDetalle;
            _newsRepository = newsRepository;
            _hostingEnv = hostingEnv;
            _userRepository = userRepository;
            _inclusionCriterios = inclusionCriterios;
            _supportPrograms = supportPrograms;
            _supportProgramsDetail = supportProgramsDetail;

        }


        [HttpGet("BackOfficeGetSupportProgramsDetail", Name = "BackOfficeGetSupportProgramsDetail")]
        //[ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<SupportProgramsDetailService>> BackOfficeGetSupportProgramsDetail(int supportProgramId)
        {
            var response = new ApiResponse<SupportProgramsDetailService>();

            try
            {
                var Result = _mapper.Map<SupportProgramsDetailService>(_supportProgramsDetail.GetSupportProgramDetail(supportProgramId));
                response.Success = true;
                response.Result = Result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });


            }

            return Ok(response);
        }


        [HttpGet("GetSupportProgramsFiltros", Name = "GetSupportProgramsFiltros")]
        public ActionResult<ApiResponse<List<SupportProgramsService>>> GetSupportProgramsFiltros(string fechaInicial, string FechaFinal, int categoriaId)
        {
            var response = new ApiResponse<List<SupportProgramsService>>();

            try
            {
                var Result = _mapper.Map<List<SupportProgramsService>>(_supportPrograms.GetSupportProgramsBackOffice(fechaInicial,FechaFinal,categoriaId));
                response.Success = true;
                response.Result = Result;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }


        [HttpGet("GetEstudioClinicoById", Name = "GetEstudioClinicoById")]
        public ActionResult<ApiResponse<estudiosClinicosService>> GetEstudioClinicoById(int clinicianStudyId)
        {
            var response = new ApiResponse<estudiosClinicosService>();

            try
            {
                var Result = _mapper.Map<estudiosClinicosService>(_studiesClinicals.GetEstudioClinicoById(clinicianStudyId));
                response.Success = true;
                response.Result = Result;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }


        [HttpGet("GetEstatusEstudiosClinicos", Name = "GetEstatusEstudiosClinicos")]
        public ActionResult<ApiResponse<List<Status>>> GetEstatusEstudiosClinicos()
        {
            var response = new ApiResponse<List<Status>>();

            try
            {
                var Result = _mapper.Map<List<Status>>(_studiesClinicals.GetStatusEstudiosClinicos());
                response.Success = true;
                response.Result = Result;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }




        [HttpGet("GetDetallePostulacionBackOffice", Name = "GetDetallePostulacionBackOffice")]
        public ActionResult<ApiResponse<postulacionesEncabezadoService>> GetDetallePostulacionBackOffice(int postulacionId)
        {
            var response = new ApiResponse<postulacionesEncabezadoService>();

            try
            {
                var Result = _mapper.Map<postulacionesEncabezadoService> (_postulaciones.GetDetallePostulacionBacoffice(postulacionId));
                response.Success = true;
                response.Result = Result;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }



        [HttpGet("GetDDLUsuariosMedicos", Name = "GetDDLUsuariosMedicos")]
        public ActionResult<ApiResponse<List<ddlMedicos>>> GetDDLUsuariosMedicos()
        {
            var response = new ApiResponse<List<ddlMedicos>>();

            try
            {
                var Result = _mapper.Map<List<ddlMedicos>>(_userRepository.GetDDLMedicos());
                response.Success = true;
                response.Result = Result;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }





        [HttpGet("GetDDLPostulaciones", Name = "GetDDLPostulaciones")]
        public ActionResult<ApiResponse<List<ddlPostulacion>>> GetDDLPostulaciones()
        {
            var response = new ApiResponse<List<ddlPostulacion>>();

            try
            {
                var Result = _mapper.Map<List<ddlPostulacion>>(_postulaciones.GetDDLPostulacion());
                response.Success = true;
                response.Result = Result;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }


        [HttpPost("UpdateNews", Name = "UpdateNews")]
        public ActionResult<ApiResponse<News>> UpdateNews(News request)
        {
            byte[] imageBytes;
            string filePath = string.Empty;
            var nombreArchivo = Guid.NewGuid();

            var response = new ApiResponse<News>();


            try
            {

                var newsRow = _newsRepository.Find(x => x.Id == request.Id);

                if (newsRow != null)
                {



                    if (!string.IsNullOrEmpty(request.PathImage))
                    {
                        //request.PathImage = request.PathImage.Replace("data:image/jpeg;base64,", "");

                        imageBytes = Convert.FromBase64String(request.PathImage);

                        if (imageBytes.Length > 0)
                        {

                            filePath = Path.Combine(_hostingEnv.ContentRootPath, "bannerNews", nombreArchivo.ToString() + ".png");

                            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                fileStream.Write(imageBytes, 0, imageBytes.Length);
                            }

                        }


                        Uri baseUri = new Uri(filePath);

                        request.PathImage = baseUri.AbsoluteUri.Replace("file:///C:", "http:/");

                        request.PathImage = request.PathImage.Replace("inetpub/wwwroot", "34.237.214.147");
                    }
                    else
                    {
                        request.PathImage = newsRow.PathImage;
                    }


                    

                    News news = _newsRepository.Update(_mapper.Map<News>(request),newsRow.Id);


                    response.Success = true;
                    response.Result = news;

                }
                else
                {
                    response.Success = true;
                    response.Message = "Noticia no encontrada";
                }

            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);


            }

            return StatusCode(201, response);

        }




        [HttpPost("addNews", Name = "addNews")]
        public ActionResult<ApiResponse<News>> addNews(News request)
        {
            byte[] imageBytes;
            string filePath = string.Empty;
            var nombreArchivo = Guid.NewGuid();

            var response = new ApiResponse<News>();


            try
            {

                if (!string.IsNullOrEmpty(request.PathImage))
                {
                    request.PathImage = request.PathImage.Replace("data:image/jpeg;base64,", "");

                    imageBytes = Convert.FromBase64String(request.PathImage);

                    if (imageBytes.Length > 0)
                    {

                        filePath = Path.Combine(_hostingEnv.ContentRootPath, "bannerNews", nombreArchivo.ToString() + ".png");

                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            fileStream.Write(imageBytes, 0, imageBytes.Length);
                        }

                    }


                    Uri baseUri = new Uri(filePath);

                    request.PathImage = baseUri.AbsoluteUri.Replace("file:///C:", "http:/");

                    request.PathImage = request.PathImage.Replace("inetpub/wwwroot", "34.237.214.147");
                }



                request.DateNews = DateTime.Now;
                News news = _newsRepository.Add(_mapper.Map<News>(request));


                response.Success = true;
                response.Result = news;



            }
            catch(Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);


            }

            return StatusCode(201, response);

        }



        [HttpGet("GetEnzabezadoEstudiosClinicosSinAprobar", Name = "GetEnzabezadoEstudiosClinicosSinAprobar")]
        public ActionResult<ApiResponse<List<encabezadoEnsayosClinicos>>> GetEnzabezadoEstudiosClinicosSinAprobar(string fechaInicial, string FechaFinal, int statusId, int categoriaId)
        {
            var response = new ApiResponse<List<encabezadoEnsayosClinicos>>();

            try
            {
                var Result = _mapper.Map<List<encabezadoEnsayosClinicos>>(_studiesClinicals.GetEncabezadoEnsayosClinicosSinAprobar(fechaInicial, FechaFinal, statusId, categoriaId));
                response.Success = true;
                response.Result = Result;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }




        [HttpGet("GetEnzabezadoEstudiosClinicos", Name = "GetEnzabezadoEstudiosClinicos")]
        public ActionResult<ApiResponse<List<encabezadoEnsayosClinicos>>> GetEnzabezadoEstudiosClinicos(string fechaInicial, string FechaFinal, int statusId, int categoriaId)
        {
            var response = new ApiResponse<List<encabezadoEnsayosClinicos>>();

            try
            {
                var Result = _mapper.Map<List<encabezadoEnsayosClinicos>>(_studiesClinicals.GetEncabezadoEnsayosClinicos(fechaInicial, FechaFinal, statusId, categoriaId));
                response.Success = true;
                response.Result = Result;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }



        [HttpGet("GetEnzabezadoPostulaciones", Name = "GetEnzabezadoPostulaciones")]
        public ActionResult<ApiResponse<List<postulacionesEncabezadoService>>> GetEnzabezadoPostulaciones(string fechaInicial, string FechaFinal, int idMedico, string idPaciente)
        {
            var response = new ApiResponse<List<postulacionesEncabezadoService>>();

            try
            {
                var Result = _mapper.Map<List<postulacionesEncabezadoService>>(_postulaciones.GetEncabezadoPostulaciones(fechaInicial, FechaFinal, idMedico, idPaciente));
                response.Success = true;
                response.Result = Result;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }




        [HttpGet("GetDashboardBackOffice", Name = "GetDashboardBackOffice")]
        public ActionResult<ApiResponse<dashboard>> GetDashboardBackOffice()
        {
            var response = new ApiResponse<dashboard>();

            try
            {
                var Result = _mapper.Map<dashboard>(_cliniclStudy.GetDashboardBackOffice());
                response.Success = true;
                response.Result = Result;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }


        [HttpPost("deleteProgramasApoyo", Name = "deleteProgramasApoyo")]
        public ActionResult<ApiResponse<bool>> deleteProgramasApoyo(int progrmaApoyoId)
        {

            var response = new ApiResponse<bool>();

            try
            {
                var programasApoyo = _programas.Find(y => y.Id == progrmaApoyoId);

                if (programasApoyo != null)
                {

                    var programasDetalle = _programasDetalle.Find(y => y.SupportProgramsId == programasApoyo.Id);

                    if (programasDetalle != null)
                    {
                        _programasDetalle.Delete(programasDetalle);
                    }

                    _programas.Delete(programasApoyo);

                    response.Success = true;
                    response.Result = true;

                }
                else
                {
                    response.Success = true;
                    response.Message = "No se encontro información";
                }

            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);


            }

            return StatusCode(201, response);

        }


        [HttpPost("deleteEstudiosClinicos", Name = "deleteEstudiosClinicos")]
        public ActionResult<ApiResponse<bool>> deleteEstudiosClinicos(int StudiesCliniciansId)
        {
            var response = new ApiResponse<bool>();

            try
            {
                var postulacionEstudio = _postulaciones.FindAll(x => x.StudiesCliniciansId == StudiesCliniciansId);

                if (postulacionEstudio.Count() == 0)
                {

                    var inclusionCriterios = _inclusionCriterios.FindAll(x => x.StudiesCliniciansId == StudiesCliniciansId);

                    if (inclusionCriterios.Count() == 0)
                    {

                        var StudiesClinicians = _studiesClinicals.Find(y => y.Id == StudiesCliniciansId);

                        if (StudiesClinicians != null)
                        {

                            var ClinicalStudy = _cliniclStudy.Find(y => y.StudiesCliniciansId == StudiesClinicians.Id);

                            if (ClinicalStudy != null)
                            {
                                _cliniclStudy.Delete(ClinicalStudy);
                            }

                            _studiesClinicals.Delete(StudiesClinicians);

                            response.Success = true;
                            response.Result = true;

                        }
                        else
                        {
                            response.Success = true;
                            response.Message = "No se encontro información";
                        }
                    }
                    else
                    {
                        response.Success = true;
                        response.Result = false;
                        response.Message = "El estudio clinico tiene criterios de inclusión asignados.";
                    }
                }
                else
                {
                    response.Success = true;
                    response.Result = false;
                    response.Message = "El estudio clinico ya tiene " + postulacionEstudio.Count() + " postulaciones asignadas.";
                }

            }
            catch(Exception ex)
            {
                response.Result = false;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);


            }

            return StatusCode(201, response);
        }



        [HttpPost("UpdateEstudiosClinicos", Name = "UpdateEstudiosClinicos")]
        public ActionResult<ApiResponse<estudiosClinicos>> UpdateEstudiosClinicos([FromBody] estudiosClinicos request)
        {
            ClinicalStudy modelClinicalStudy = new ClinicalStudy();
            StudiesClinicians modelStudiesClinician = new StudiesClinicians();
            estudiosClinicos modelResponse = new estudiosClinicos();

            var response = new ApiResponse<estudiosClinicos>();

            try
            {

                if (request != null)
                {

                    modelStudiesClinician = _studiesClinicals.Find(x => x.Id == request.Id);

                    if (modelStudiesClinician != null)
                    {

                        modelStudiesClinician.PublicationDate = request.PublicationDate;
                        modelStudiesClinician.SatatusId = request.SatatusId;
                        modelStudiesClinician.StudyCategoryId = request.StudyCategoryId;
                        modelStudiesClinician.Title = request.Title;
                        modelStudiesClinician.StudyContent = request.StudyContent;
                        modelStudiesClinician.Approved = request.Approved;
                        modelStudiesClinician.Name = request.Name;

                        modelStudiesClinician = _studiesClinicals.Update(_mapper.Map<StudiesClinicians>(modelStudiesClinician), modelStudiesClinician.Id);

                        if (modelStudiesClinician != null)
                        {

                            modelClinicalStudy = _cliniclStudy.Find(j => j.StudiesCliniciansId == modelStudiesClinician.Id);

                            if (modelClinicalStudy != null)
                            {

                               
                                modelClinicalStudy.PublicationDate = request.PublicationDate;
                                modelClinicalStudy.MainIntervention = request.MainIntervention;
                                modelClinicalStudy.ProtocolNumber = request.ProtocolNumber;
                                modelClinicalStudy.AgeRange = request.AgeRange;
                                modelClinicalStudy.AgeRangeId = request.AgeRangeId;
                                modelClinicalStudy.StudyTypeId = request.StudyTypeId;
                                modelClinicalStudy.Description = request.Description;

                                modelClinicalStudy = _cliniclStudy.Update(_mapper.Map<ClinicalStudy>(modelClinicalStudy), modelClinicalStudy.Id);

                            }
                        }

                        modelResponse.Id = modelStudiesClinician.Id;
                        modelResponse.PublicationDate = modelStudiesClinician.PublicationDate;
                        modelResponse.SatatusId = modelStudiesClinician.SatatusId;
                        modelResponse.StudyCategoryId = modelStudiesClinician.StudyCategoryId;
                        modelResponse.Title = modelStudiesClinician.Title;
                        modelResponse.StudyContent = modelStudiesClinician.StudyContent;
                        modelResponse.Name = modelStudiesClinician.Name;

                        //detalle

                        modelResponse.PublicationDate = modelClinicalStudy.PublicationDate;
                        modelResponse.MainIntervention = modelClinicalStudy.MainIntervention;
                        modelResponse.ProtocolNumber = modelClinicalStudy.ProtocolNumber;
                        modelResponse.AgeRange = modelClinicalStudy.AgeRange;
                        modelResponse.StudyTypeId = modelClinicalStudy.StudyTypeId;
                        modelResponse.Description = modelClinicalStudy.Description;

                        response.Success = true;
                        response.Result = modelResponse;
                    }

                }
                else
                {
                    response.Success = true;
                    response.Message = "No existe información para registrar";

                }

            }
            catch (Exception ex)
            {

                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);


            }


            return StatusCode(201, response);

        }





        [HttpPost("UpdateProgramasApoyo", Name = "UpdateProgramasApoyo")]
        public ActionResult<ApiResponse<programasApoyo>> UpdateProgramasApoyo([FromBody] programasApoyo request)
        {
            SupportPrograms modelProgramas = new SupportPrograms();
            SupportProgramsDetail modelProgramasDetail = new SupportProgramsDetail();
            programasApoyo modelResponse = new programasApoyo();

            var response = new ApiResponse<programasApoyo>();

            try
            {

                if (request != null)
                {

                    var programaApoyo = _supportPrograms.Find(x => x.Id == request.Id);

                    if (programaApoyo != null)
                    {

                        modelProgramas.Id = request.Id;
                        modelProgramas.StudyCategoryId = request.StudyCategoryId;
                        modelProgramas.ProgramTitle = request.ProgramTitle;
                        modelProgramas.ProgramContent = request.ProgramContent;
                        modelProgramas.PublicationDate = request.PublicationDate;
                        modelProgramas.Active = request.Active;
                        modelProgramas.Summary = request.Summary;
                        modelProgramas.Approved = request.Approved;


                        modelProgramas = _programas.Update(_mapper.Map<SupportPrograms>(modelProgramas), modelProgramas.Id);

                        if (modelProgramas != null)
                        {
                            modelProgramasDetail = _supportProgramsDetail.Find(i => i.SupportProgramsId == modelProgramas.Id);

                            if (modelProgramasDetail != null)
                            {
                                modelProgramasDetail.SupportProgramsId = modelProgramas.Id;
                                modelProgramasDetail.MainIntervention = request.MainIntervention;
                                modelProgramasDetail.Description = request.Description;
                                modelProgramasDetail.PublicationDate = request.PublicationDate;
                                modelProgramasDetail.RegistrationDate = DateTime.Now;
                                modelProgramasDetail.Active = request.Active;
                                modelProgramasDetail.StudyTypeId = 0;
                                modelProgramasDetail.AgeRange = "";


                                modelProgramasDetail = _programasDetalle.Update(_mapper.Map<SupportProgramsDetail>(modelProgramasDetail), modelProgramasDetail.Id);
                            }


                        }

                        modelResponse.Id = modelProgramas.Id;
                        modelResponse.StudyCategoryId = modelProgramas.StudyCategoryId;
                        modelResponse.ProgramTitle = modelProgramas.ProgramTitle;
                        modelResponse.ProgramContent = modelProgramas.ProgramContent;
                        modelResponse.PublicationDate = modelProgramas.PublicationDate;
                        modelResponse.Active = modelProgramas.Active;
                        modelResponse.Summary = modelProgramas.Summary;
                        modelResponse.Approved = modelProgramas.Approved;


                        //detalle

                        modelResponse.SupportProgramsId = modelProgramasDetail.SupportProgramsId;
                        modelResponse.MainIntervention = modelProgramasDetail.MainIntervention;
                        modelResponse.Description = modelProgramasDetail.Description;
                        modelResponse.PublicationDate = modelProgramasDetail.PublicationDate;
                        modelResponse.RegistrationDate = modelProgramasDetail.RegistrationDate;
                        modelResponse.Active = modelProgramasDetail.Active;
                        modelResponse.StudyTypeId = modelProgramasDetail.StudyTypeId;
                        modelResponse.AgeRange = modelProgramasDetail.AgeRange;


                        response.Success = true;
                        response.Result = modelResponse;
                    }

                }
                else
                {
                    response.Success = true;
                    response.Message = "No existe información para registrar";

                }

            }
            catch (Exception ex)
            {

                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);


            }


            return StatusCode(201, response);

        }




        [HttpPost("AddProgramasApoyo", Name = "AddProgramasApoyo")]
        public ActionResult<ApiResponse<programasApoyo>> AddProgramasApoyo([FromBody] programasApoyo request)
        {
            SupportPrograms modelProgramas = new SupportPrograms();
            SupportProgramsDetail modelProgramasDetail = new SupportProgramsDetail();
            programasApoyo modelResponse = new programasApoyo();

            var response = new ApiResponse<programasApoyo>();

            try
            {

                if (request != null)
                {
                    modelProgramas.Id = request.Id;
                    modelProgramas.StudyCategoryId = request.StudyCategoryId;
                    modelProgramas.ProgramTitle = request.ProgramTitle;
                    modelProgramas.ProgramContent = request.ProgramContent;
                    modelProgramas.PublicationDate = request.PublicationDate;
                    modelProgramas.Active = request.Active;
                    modelProgramas.Summary = request.Summary;
                    modelProgramas.Approved = request.Approved;


                    modelProgramas = _programas.Add(_mapper.Map<SupportPrograms>(modelProgramas));

                    if (modelProgramas != null)
                    {
                        modelProgramasDetail.SupportProgramsId = modelProgramas.Id;
                        modelProgramasDetail.MainIntervention = request.MainIntervention;
                        modelProgramasDetail.Description = request.Description;
                        modelProgramasDetail.PublicationDate = request.PublicationDate;
                        modelProgramasDetail.RegistrationDate = DateTime.Now;
                        modelProgramasDetail.Active = request.Active;
                        modelProgramasDetail.StudyTypeId = 0;
                        modelProgramasDetail.AgeRange = "";


                        modelProgramasDetail = _programasDetalle.Add(_mapper.Map<SupportProgramsDetail>(modelProgramasDetail));


                    }

                    modelResponse.Id =  modelProgramas.Id;
                    modelResponse.StudyCategoryId = modelProgramas.StudyCategoryId;
                    modelResponse.ProgramTitle = modelProgramas.ProgramTitle;
                    modelResponse.ProgramContent = modelProgramas.ProgramContent;
                    modelResponse.PublicationDate = modelProgramas.PublicationDate;
                    modelResponse.Active = modelProgramas.Active;
                    modelResponse.Summary = modelProgramas.Summary;
                    modelResponse.Approved = modelProgramas.Approved;


                    //detalle

                    modelResponse.SupportProgramsId =modelProgramasDetail.SupportProgramsId;
                    modelResponse.MainIntervention =modelProgramasDetail.MainIntervention;
                    modelResponse.Description =modelProgramasDetail.Description;
                    modelResponse.PublicationDate = modelProgramasDetail.PublicationDate;
                    modelResponse.RegistrationDate = modelProgramasDetail.RegistrationDate;
                    modelResponse.Active = modelProgramasDetail.Active;
                    modelResponse.StudyTypeId = modelProgramasDetail.StudyTypeId;
                    modelResponse.AgeRange = modelProgramasDetail.AgeRange;


                    response.Success = true;
                    response.Result = modelResponse;

                }
                else
                {
                    response.Success = true;
                    response.Message = "No existe información para registrar";

                }

            }
            catch (Exception ex)
            {

                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);


            }


            return StatusCode(201, response);

        }







        [HttpPost("AddEstudiosClinicos", Name = "AddEstudiosClinicos")]
        public ActionResult<ApiResponse<estudiosClinicos>> AddEstudiosClinicos([FromBody] estudiosClinicos request)
        {
            ClinicalStudy modelClinicalStudy = new ClinicalStudy();
            StudiesClinicians modelStudiesClinician = new StudiesClinicians();
            estudiosClinicos modelResponse = new estudiosClinicos();

            var response = new ApiResponse<estudiosClinicos>();

            try
            {

                if (request != null)
                {
                    modelStudiesClinician.Id = request.Id;
                    modelStudiesClinician.PublicationDate = request.PublicationDate;
                    modelStudiesClinician.SatatusId = request.SatatusId;
                    modelStudiesClinician.StudyCategoryId = request.StudyCategoryId;
                    modelStudiesClinician.Title = request.Title;
                    modelStudiesClinician.StudyContent = request.StudyContent;
                    modelStudiesClinician.Approved = false;
                    modelStudiesClinician.Name = request.Name;

                    modelStudiesClinician = _studiesClinicals.Add(_mapper.Map<StudiesClinicians>(modelStudiesClinician));

                    if (modelStudiesClinician != null)
                    {
                        modelClinicalStudy.StudiesCliniciansId = modelStudiesClinician.Id;
                        modelClinicalStudy.PublicationDate = request.PublicationDate;
                        modelClinicalStudy.MainIntervention = request.MainIntervention;
                        modelClinicalStudy.ProtocolNumber = request.ProtocolNumber;
                        modelClinicalStudy.AgeRange = request.AgeRange;
                        modelClinicalStudy.StudyTypeId = request.StudyTypeId;
                        modelClinicalStudy.Description = request.Description;
                        modelClinicalStudy.AgeRangeId = request.AgeRangeId;

                        modelClinicalStudy = _cliniclStudy.Add(_mapper.Map<ClinicalStudy>(modelClinicalStudy));


                    }

                    modelResponse.Id = modelStudiesClinician.Id;
                    modelResponse.PublicationDate = modelStudiesClinician.PublicationDate;
                    modelResponse.SatatusId = modelStudiesClinician.SatatusId;
                    modelResponse.StudyCategoryId = modelStudiesClinician.StudyCategoryId;
                    modelResponse.Title = modelStudiesClinician.Title;
                    modelResponse.StudyContent = modelStudiesClinician.StudyContent;
                    modelResponse.Name = modelStudiesClinician.Name;

                    //detalle
                    
                    modelResponse.PublicationDate = modelClinicalStudy.PublicationDate;
                    modelResponse.MainIntervention = modelClinicalStudy.MainIntervention;
                    modelResponse.ProtocolNumber = modelClinicalStudy.ProtocolNumber;
                    modelResponse.AgeRange = modelClinicalStudy.AgeRange;
                    modelResponse.AgeRangeId = modelClinicalStudy.AgeRangeId;
                    modelResponse.StudyTypeId = modelClinicalStudy.StudyTypeId;
                    modelResponse.Description = modelClinicalStudy.Description;

                    response.Success = true;
                    response.Result = modelResponse;

                }
                else
                {
                    response.Success = true;
                    response.Message = "No existe información para registrar";
                   
                }

            }
            catch (Exception ex)
            {

                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);


            }


            return StatusCode(201, response);

        }





       [HttpPost("AddShareStudies", Name = "AddShareStudies")]
        public ActionResult<ApiResponse<ShareClinicalStudies>> AddShareStudies([FromBody] shareStudies request)
        {
            ShareClinicalStudies modelRequest = new ShareClinicalStudies();

            var response = new ApiResponse<ShareClinicalStudies>();

            try
            {
                modelRequest.StudiesCliniciansId = request.studiesCliniciansId;
                modelRequest.CreationDate = DateTime.Now;

                var sharesStudies = _shareStudies.Add(_mapper.Map<ShareClinicalStudies>(modelRequest));

                response.Success = true;
                response.Result = sharesStudies;


            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);


            }

            return StatusCode(201, response);

        }



    }
}
