using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.guerreros.ActionFilter;
using api.guerreros.Models;
using biz.guerreros.Entities;
using biz.guerreros.Models.Postulation;
using biz.guerreros.Models.Specialty;
using biz.guerreros.Repository.Postulation;
using biz.guerreros.Repository.Specialty;
using biz.guerreros.Servicies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.guerreros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly ISpecialty _specialty;
        private readonly IPostulation _postulation;

        public DoctorController(ISpecialty specialty,
            AutoMapper.IMapper mapper,
        ILoggerManager logger,
        IPostulation postulation)
        {
            _mapper = mapper;
            _logger = logger;
            _specialty = specialty;
            _postulation = postulation;
        }

        [HttpGet("GetAllSpecialty", Name = "GetAllSpecialty")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<SpecialtyService>>> GetAllSpecialty()
        {
            var response = new ApiResponse<List<SpecialtyService>>();

            try
            {
                var Result = _mapper.Map<List<SpecialtyService>>(_specialty.GetAllSpecialty());
                response.Success = true;
                response.Result = Result;

            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }


        [HttpPost("UpdatePostulation", Name = "UpdatePostulation")]
        public ActionResult<ApiResponse<Postulation>> UpdatePostulation([FromBody] Postulation request)
        {
            string aleatorio = "";
            var response = new ApiResponse<Postulation>();

            try
            {
                var postulacion = _postulation.Find(x => x.Id == request.Id);

                if (postulacion != null)
                {

                    request.RegistrationDate = DateTime.Now;



                    response.Result = _mapper.Map<Postulation>(_postulation.Update(request, postulacion.Id));
                    response.Success = true;
                    response.Message = "Success";

                }
                else
                {
                    response.Success = true;
                    response.Message = "No se encontro los datos de la postulación";
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

            return Ok(response);

        }

        [HttpPost("AddNewPostulation", Name = "AddNewPostulation")]
        public ActionResult<ApiResponse<Postulation>> AddNewPostulation([FromBody] Postulation request)
        {
            string aleatorio = "";
            var response = new ApiResponse<Postulation>();

            try
            {


                try
                {
                    aleatorio = GenerateRandoms();
                }
                catch (Exception ex)
                {
                    aleatorio = GenerateRandoms();
                }

                request.PatientCode = aleatorio;
                request.Active = true;
                while (_postulation.Exists(c => c.PatientCode == request.PatientCode))
                {
                    try
                    {
                        aleatorio = GenerateRandoms();
                    }
                    catch (Exception ex)
                    {
                        aleatorio = GenerateRandoms();
                    }

                    request.PatientCode = aleatorio;
                    
                }

                request.RegistrationDate = DateTime.Now;



                response.Result = _mapper.Map<Postulation>(_postulation.Add(request));
                response.Success = true;
                response.Message = "Success";



            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);
            }

            return Ok(response);

        }


        [HttpGet("GenerateRandoms", Name = "GenerateRandoms")]
        public System.String GenerateRandoms()
        {
            System.Random randomGenerate = new System.Random();
            System.String sPassword = "";
            sPassword = System.Convert.ToString(randomGenerate.Next(00000001, 99999999));
            return sPassword.Substring(sPassword.Length - 8, 8);
        }

        [HttpGet("GetPostulationByDoctorId", Name = "GetPostulationByDoctorId")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<postulationService>>> GetPostulationByDoctorId(int doctorId)
        {

            var response = new ApiResponse<List<postulationService>>();


            try
            {
                var Result = _mapper.Map<List<postulationService>>(_postulation.GetPostulationByDoctorId(doctorId));
                response.Result = Result;
                response.Success = true;
                

            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }

        [HttpGet("GetPostulationDetail", Name = "GetPostulationDetail")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<postulationService>> GetPostulationDetail(int postulationId)
        {
            var response = new ApiResponse<postulationService>();


            try
            {
                var Result = _mapper.Map<postulationService>(_postulation.GetPostulationDetail(postulationId));
                response.Result = Result;
                response.Success = true;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }
    }
}
