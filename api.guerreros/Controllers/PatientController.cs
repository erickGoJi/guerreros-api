using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api.guerreros.ActionFilter;
using api.guerreros.Models;
using biz.guerreros.Entities;
using biz.guerreros.Models.AgeRange;
using biz.guerreros.Models.ClinicalStudy;
using biz.guerreros.Models.ContactGuerreros;
using biz.guerreros.Models.Contacts;
using biz.guerreros.Models.ddlStudy;
using biz.guerreros.Models.InclusionCriteria;
using biz.guerreros.Models.InformationGuerreros;
using biz.guerreros.Models.News;
using biz.guerreros.Models.Notifications;
using biz.guerreros.Models.ResearchSite;
using biz.guerreros.Models.SponsorsGuerreros;
using biz.guerreros.Models.SponsorsGuerrerosDetail;
using biz.guerreros.Models.StudiClinicians;
using biz.guerreros.Models.StudyCategory;
using biz.guerreros.Models.StudyType;
using biz.guerreros.Models.SupportPrograms;
using biz.guerreros.Models.SupportProgramsDetail;
using biz.guerreros.Models.Users;
using biz.guerreros.Repository.ClinicalStudy;
using biz.guerreros.Repository.ContactGuerreros;
using biz.guerreros.Repository.Contacts;
using biz.guerreros.Repository.InclusionCriteria;
using biz.guerreros.Repository.InformationGuerreros;
using biz.guerreros.Repository.News;
using biz.guerreros.Repository.Notifications;
using biz.guerreros.Repository.ResearchSite;
using biz.guerreros.Repository.SponsorsGuerreros;
using biz.guerreros.Repository.SponsorsGuerrerosDetail;
using biz.guerreros.Repository.StudiesClinicians;
using biz.guerreros.Repository.StudyCategory;
using biz.guerreros.Repository.StudyType;
using biz.guerreros.Repository.SupportPrograms;
using biz.guerreros.Repository.SupportProgramsDetail;
using biz.guerreros.Repository.Users;
using biz.guerreros.Servicies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.guerreros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IStudyCategory _studyCategoryRepository;
        private readonly IStudiesClinicians _studiesCliniciansRepository;
        private readonly INews _newsRepository;
        private readonly IStudyType _studyTypeRepository;
        private readonly IClinicalStudy _clinicalstudyRepository;
        private readonly IResearchSite _researchSiteRepository;
        private readonly IinclusionCriteria _inclusionCriteria;
        private readonly IContacts _contacts;
        private readonly IinformationGuerreros _informationGuerreros;
        private readonly IcontactGuerreros _contactGuerreros;
        private readonly INotifications _notifications;
        private readonly ISupportPrograms _supportPrograms;
        private readonly ISupportProgramsDetail _supportProgramDetail;
        private readonly ISponsorsGuerreros _sponsorGuerreros;
        private readonly ISponsorsGuerrerosDetail _sponsorGuerrerosDetail;
        private readonly IUsers _Users;
        private readonly IWebHostEnvironment _hostingEnv;
        public PatientController(
            AutoMapper.IMapper mapper,
        ILoggerManager logger,
        IStudyCategory studyCategoryRepository,
        IStudiesClinicians studiesCliniciansRepository,
        INews newsRepository,
        IStudyType studyTypeRepository,
        IClinicalStudy clinicalStudyRepository,
        IResearchSite researchSiteRepository,
        IinclusionCriteria inclusionCriteria,
        IContacts contacts,
        IinformationGuerreros informationGuerreros,
        IcontactGuerreros contactGuerreros,
        INotifications notifications,
        ISupportPrograms supportPrograms,
        ISupportProgramsDetail supportProgramDetail,
        ISponsorsGuerreros sponsorGuerreros,
        ISponsorsGuerrerosDetail sponsorGuerrerosDetail,
        IUsers Users,
        IWebHostEnvironment hostingEnv)
        {
            _mapper = mapper;
            _logger = logger;
            _studyCategoryRepository = studyCategoryRepository;
            _studiesCliniciansRepository = studiesCliniciansRepository;
            _newsRepository = newsRepository;
            _studyTypeRepository = studyTypeRepository;
            _clinicalstudyRepository = clinicalStudyRepository;
            _researchSiteRepository = researchSiteRepository;
            _inclusionCriteria = inclusionCriteria;
            _contacts = contacts;
            _informationGuerreros = informationGuerreros;
            _contactGuerreros = contactGuerreros;
            _notifications = notifications;
            _supportPrograms = supportPrograms;
            _supportProgramDetail = supportProgramDetail;
            _sponsorGuerreros = sponsorGuerreros;
            _sponsorGuerrerosDetail = sponsorGuerrerosDetail;
            _Users = Users;
            _hostingEnv = hostingEnv;
        }


        [HttpGet("GetServiceStudyCategory", Name = "GetServiceStudyCategory")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<studyCategoryService>>> GetServiceStudyCategory()
        {
            var response = new ApiResponse<List<studyCategoryService>>();

            try
            {
                var Result = _mapper.Map<List<studyCategoryService>>(_studyCategoryRepository.GetAllStudyCategory());
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

        [HttpGet("GetServiceStudyCategoryById", Name = "GetServiceStudyCategoryById")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<studyCategoryService>> GetServiceStudyCategoryById(int categoryId)
        {
            var response = new ApiResponse<studyCategoryService>();

            try
            {
                var Result = _mapper.Map<studyCategoryService>(_studyCategoryRepository.GetAllStudyCategory().Where(i => i.Id == categoryId).FirstOrDefault());
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

        [HttpGet("GetServiceNewsStudiesClinicians", Name = "GetServiceNewsStudiesClinicians")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<StudiCliniciansService>>> GetServiceNewsStudiesClinicians()
        {
            var response = new ApiResponse<List<StudiCliniciansService>>();

            try
            {
                var Result = _mapper.Map<List<StudiCliniciansService>>(_studiesCliniciansRepository.GetAllNewsStudiesClinicians());
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


        [HttpGet("GetNews", Name = "GetNews")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<NewsService>>> GetNews()
        {
            var response = new ApiResponse<List<NewsService>>();

            try
            {
                var Result = _mapper.Map<List<NewsService>>(_newsRepository.GetAllNews());
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

        [HttpGet("GetStudiesCliniciansByCategoryId", Name = "GetStudiesCliniciansByCategoryId")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<StudiCliniciansService>>> GetStudiesCliniciansByCategoryId(int CategoryId)
        {

            var response = new ApiResponse<List<StudiCliniciansService>>();

            try
            {
                var Result = _mapper.Map<List<StudiCliniciansService>>(_studiesCliniciansRepository.GetStudiesCliniciansByCategory(CategoryId));
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


        [HttpGet("GetAllStudyType", Name = "GetAllStudyType")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<StudyTypeServie>>> GetAllStudyType()
        {
            var response = new ApiResponse<List<StudyTypeServie>>();

            try
            {
                var Result = _mapper.Map<List<StudyTypeServie>>(_studyTypeRepository.GetAllTypeStudy());
                Result.Add(new StudyTypeServie { Id = 0,Name="Tipo de estudio" }) ;
                response.Success = true;
                response.Result = Result.OrderBy(i => i.Id).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);

        }


        [HttpGet("GetStudiesCliniciansByCategoryText", Name = "GetStudiesCliniciansByCategoryText")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<StudiCliniciansService>>> GetStudiesCliniciansByCategoryText(string Category)
        {
            var response = new ApiResponse<List<StudiCliniciansService>>();


            try
            {
                var Result = _mapper.Map<List<StudiCliniciansService>>(_studiesCliniciansRepository.GetStudiesCliniciansByCategoryText(Category));
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


        [HttpGet("GetClinicalStudyDetail", Name = "GetClinicalStudyDetail")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<ClinicalStudyService>> GetClinicalStudyDetail(int StudiesCliniciansId)
        {
            var response = new ApiResponse<ClinicalStudyService>();

            try
            {
                var Result = _mapper.Map<ClinicalStudyService>(_clinicalstudyRepository.GetClinicalStudyDetail(StudiesCliniciansId));
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

        [HttpGet("GetReserchSite", Name = "GetReserchSite")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<ResearchSiteService>>> GetReserchSite()
        {
            var response = new ApiResponse<List<ResearchSiteService>>();

            try
            {
                var Result = _mapper.Map<List<ResearchSiteService>>(_researchSiteRepository.GetAllResearchSite());
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


        [HttpGet("GetStudiesCliniciansByCategoryTextTypeStudyAgeRange", Name = "GetStudiesCliniciansByCategoryTextTypeStudyAgeRange")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<StudiCliniciansService>>> GetStudiesCliniciansByCategoryTextTypeStudyAgeRange(int Category, int typeStudy, int ageRange, string name)
        {
            var response = new ApiResponse<List<StudiCliniciansService>>();


            try
            {
                var Result = _mapper.Map<List<StudiCliniciansService>>(_studiesCliniciansRepository.GetStudiesCliniciansCategoryTextByTypeStudy(Category,typeStudy,ageRange, name));
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

        [HttpGet("GetAllAgeRange", Name = "GetAllAgeRange")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<ageRangeService>>> GetAllAgeRange()
        {
            var response = new ApiResponse<List<ageRangeService>>();


            try
            {
                var Result = _mapper.Map<List<ageRangeService>>(_clinicalstudyRepository.GetAllAgeRage());
                Result.Add(new ageRangeService { Id = 0, AgeRange = "Población dirigida" });
                response.Success = true;
                response.Result = Result.OrderBy(i => i.Id).ToList();


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }

        [HttpGet("GetAllDiseases", Name = "GetAllDiseases")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<CatDiseasesDto>>> GetAllDiseases()
        {
            var response = new ApiResponse<List<CatDiseasesDto>>();


            try
            {
                var Result = _mapper.Map<List<CatDiseasesDto>>(_clinicalstudyRepository.GetAllDiseases());
                Result.Add(new CatDiseasesDto { Name = "Enfermedad" });
                response.Success = true;
                response.Result = Result.OrderBy(i => i.Name).ToList();


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }

        [HttpGet("GetInclusionCriteriaByClinicalStudy", Name = "GetInclusionCriteriaByClinicalStudy")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<inclusionCriteriaService>>> GetInclusionCriteriaByClinicalStudy(int StudiesCliniciansId)
        {
            var response = new ApiResponse<List<inclusionCriteriaService>>();

            try
            {
                var result = _mapper.Map<List<inclusionCriteriaService>>(_inclusionCriteria.GetAllInclusionCriteria(StudiesCliniciansId));
                response.Success = true;
                response.Result = result;

            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return Ok(response);
            return Ok(response);
        }

        [HttpGet("GetAllContacts", Name = "GetAllContacts")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<contactsService>>> GetAllContacts()
        {
            var response = new ApiResponse<List<contactsService>>();

            try
            {
                var Result = _mapper.Map<List<contactsService>>(_contacts.GetAllContacts());
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

        [HttpGet("GetNewsById", Name = "GetNewsById")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<NewsService>> GetNewsById(int NewsId)
        {
            var response = new ApiResponse<NewsService>();

            try
            {
                var result = _mapper.Map<NewsService>(_newsRepository.GetNewsById(NewsId));
                response.Success = true;
                response.Result = result;

            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return Ok(response);
        }

        [HttpGet("GetInformationGuerreros", Name = "GetInformationGuerreros")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<informationGuerrerosService>> GetInformationGuerreros()
        {
            var response = new ApiResponse<informationGuerrerosService>();

            try
            {
                var Result = _mapper.Map<informationGuerrerosService>(_informationGuerreros.GetInformationGuerreros());
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

        [HttpGet("GetContactGuerreros", Name = "GetContactGuerreros")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<contactGuerrerosService>> GetContactGuerreros()
        {
            var response = new ApiResponse<contactGuerrerosService>();

            try
            {
                var Result = _mapper.Map<contactGuerrerosService>(_contactGuerreros.GetContactGuerreros());
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

        [HttpPost("AddNewNotifications", Name = "AddNewNotifications")]
        public ActionResult<ApiResponse<Notifications>> PostNotification([FromBody] Notifications request)
        {
            var response = new ApiResponse<Notifications>();

            try
            {
                response.Success = true;
                response.Message = "Success";
                response.Result = _mapper.Map<Notifications>(_notifications.Add(request));

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

        [HttpGet("GetDDLStudy", Name = "GetDDLStudy")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<ddlStudyService>>> GetDDLStudy()
        {

            var response = new ApiResponse<List<ddlStudyService>>();

            try
            {
                var result = _mapper.Map<List<ddlStudyService>>(_notifications.GetDDLStudy());
                response.Success = true;
                response.Result = result;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return Ok(response);
        }


        [HttpGet("GetSupportPrograms", Name = "GetSupportPrograms")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<SupportProgramsService>>> GetSupportPrograms()
        {
            var response = new ApiResponse<List<SupportProgramsService>>();

            try
            {
                var result = _mapper.Map<List<SupportProgramsService>>(_supportPrograms.GetSupportPrograms());
                response.Success = true;
                response.Result = result;


            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }


        [HttpGet("GetSupportProgramsByCategoryId", Name = "GetSupportProgramsByCategoryId")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<SupportProgramsService>>> GetSupportProgramsByCategoryId(int CategoryId)
        {
            var response = new ApiResponse<List<SupportProgramsService>>();

            try
            {
                var result = _mapper.Map<List<SupportProgramsService>>(_supportPrograms.GetSupportProgramsByCategoryId(CategoryId));
                response.Success = true;
                response.Result = result;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });


            }

            return Ok(response);
        }

        [HttpGet("GetSupportProgramsByCategoryText", Name = "GetSupportProgramsByCategoryText")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<SupportProgramsService>>> GetSupportProgramsByCategoryText(string category)
        {
            var response = new ApiResponse<List<SupportProgramsService>>();

            try
            {
                var result = _mapper.Map<List<SupportProgramsService>>(_supportPrograms.GetSupportProgramsByCategoryText(category));
                response.Success = true;
                response.Result = result;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });


            }

            return Ok(response);
        }

        [HttpGet("GetSupportProgramsByCategoryProgramTypeAgeRange", Name = "GetSupportProgramsByCategoryProgramTypeAgeRange")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<SupportProgramsService>>> GetSupportProgramsByCategoryProgramTypeAgeRange(int category,int typeProgram, int ageRange, string name)
        {
            var response = new ApiResponse<List<SupportProgramsService>>();

            try
            {
                var result = _mapper.Map<List<SupportProgramsService>>(_supportPrograms.GetSupportProgramsByCategoryProgramTypeAgeRange(category,typeProgram,ageRange,name));
                response.Success = true;
                response.Result = result;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });


            }

            return Ok(response);
        }


        [HttpGet("GetSupportProgramsDetail", Name = "GetSupportProgramsDetail")]
        //[ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<SupportProgramsDetailService>> GetSupportProgramsDetail(int supportProgramId)
        {
            var response = new ApiResponse<SupportProgramsDetailService>();

            try
            {
                var Result = _mapper.Map<SupportProgramsDetailService>(_supportProgramDetail.GetSupportProgramDetail(supportProgramId));
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

        [HttpGet("GetSponsorsGuerreros", Name = "GetSponsorsGuerreros")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<SponsorsGuerrerosService>> GetSponsorsGuerreros()
        {
            var response = new ApiResponse<SponsorsGuerrerosService>();

            try
            {
                var Result = _mapper.Map<SponsorsGuerrerosService>(_sponsorGuerreros.GetSponsorsGuerreros());
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

        [HttpGet("GetSponsorsGuerrerosDetailColaborador", Name = "GetSponsorsGuerrerosDetailColaborador")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<SponsorsGuerrerosDetailService>>> GetSponsorsGuerrerosDetailColaborador()
        {
            var response = new ApiResponse<List<SponsorsGuerrerosDetailService>>();
            try
            {
                var Result = _mapper.Map<List<SponsorsGuerrerosDetailService>>(_sponsorGuerrerosDetail.GetSponsorsGuerrerosDetailColaboradores());
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

        [HttpGet("GetSponsorsGuerrerosDetail", Name = "GetSponsorsGuerrerosDetail")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<List<SponsorsGuerrerosDetailService>>> GetSponsorsGuerrerosDetail()
        {

            var response = new ApiResponse<List<SponsorsGuerrerosDetailService>>();
            try
            {
                var Result = _mapper.Map<List<SponsorsGuerrerosDetailService>>(_sponsorGuerrerosDetail.GetSponsorsGuerrerosDetail());
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

        
    }
}