using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using api.guerreros.ActionFilter;
using api.guerreros.Models;
using biz.guerreros.Entities;
using biz.guerreros.Paged;
using biz.guerreros.Repository;
using biz.guerreros.Servicies;
using System;
using System.Collections.Generic;
using biz.guerreros.Models.Users;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using biz.guerreros.Models.Email;
using Microsoft.AspNetCore.Identity;
using biz.guerreros.Repository.Postulation;

namespace api.guerreros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly IPostulation _postulaciones;
        public UserController(
            IMapper mapper,
            ILoggerManager logger,
            IUserRepository userRepository,
            IWebHostEnvironment hostingEnv,
            IPostulation postulacion)
        {
            _mapper = mapper;
            _logger = logger;
            _userRepository = userRepository;
            _hostingEnv = hostingEnv;
            _postulaciones = postulacion;
        }



        [HttpPost("deleteUsuario", Name = "deleteUsuario")]
        public ActionResult<ApiResponse<bool>> deleteUsuario(int idUsuario)
        {
            ShareClinicalStudies modelRequest = new ShareClinicalStudies();

            var response = new ApiResponse<bool>();

            try
            {

                var usuarioPostulacion = _postulaciones.FindAll(x => x.UserId == idUsuario);

                //if (usuarioPostulacion.Count == 0)
                //{

                    var usuario = _userRepository.Find(x => x.Id == idUsuario);
                    if (usuario != null)
                    {


                        usuario.Active = false;
                        _userRepository.Delete(usuario);

                        response.Success = true;
                        response.Result = true;

                    }
                    else
                    {

                        response.Result = false;
                        response.Message = "Usuario no encontrado";

                    }
                //}
                //else
                //{
                //    response.Success = true;
                //    response.Result = false;
                //    response.Message = "El usuario tiene postulaciones realizadas. No se puede eliminar";
                //}


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



        [HttpGet("GetUsuarioById", Name = "GetUsuarioById")]
        public ActionResult<ApiResponse<UsersService>> GetUsuarioById(int id)
        {
            var response = new ApiResponse<UsersService>();

            try
            {
                var Result = _mapper.Map<UsersService>(_userRepository.GetUsuarioById(id));
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



        [HttpGet("GetCuentasMedicos", Name = "GetCuentasMedicos")]
        public ActionResult<ApiResponse<List<usuarioMedico>>> GetCuentasMedicos(string fechaInicial, string FechaFinal, int specialityId, string name)
        {
            var response = new ApiResponse<List<usuarioMedico>>();

            try
            {
                var Result = _mapper.Map<List<usuarioMedico>>(_userRepository.GetUsersByFilter(fechaInicial, FechaFinal,specialityId,name));
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





        [HttpGet]
        public ActionResult<ApiResponse<List<UserDto>>> GetAll()
        {
            var response = new ApiResponse<List<UserDto>>();

            try
            {
                response.Result = _mapper.Map<List<UserDto>>(_userRepository.GetAll());
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = "Internal server error";
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public ActionResult<ApiResponse<PagedList<UserDto>>> GetPaged(int pageNumber, int pageSize)
        {
            var response = new ApiResponse<PagedList<UserDto>>();

            try
            {
                response.Result = _mapper.Map<PagedList<UserDto>>
                    (_userRepository.GetAllPaged(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = "Internal server error";
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        [HttpGet("GetById", Name = "GetById")]
        public ActionResult<ApiResponse<UserDto>> GetById(int id)
        {
            var response = new ApiResponse<UserDto>();

            try
            {

                response.Result = _mapper.Map<UserDto>(_userRepository.Find(c => c.Id == id));
                response.Result.Avatar = response.Result.Avatar.Replace("inetpub/wwwroot", "34.237.214.147");
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = "Internal server error";
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, response);
            }

            return Ok(response);
        }





        [HttpGet("GetUserByEmail", Name = "GetUserByEmail")]
        public ActionResult<ApiResponse<Users>> GetUserByEmail(string email, string code)
        {
            var response = new ApiResponse<Users>();

            try
            {
                var user = _mapper.Map<Users>(_userRepository.Find(c => c.Email == email && c.VerificationCode == code));

                if(user != null)
                {
                    user.Verified = true;
                    user = _userRepository.Update(_mapper.Map<Users>(user), user.Id);

                    response.Success = true;
                    response.Result = user;
                }
                else
                {
                    response.Success = true;
                    response.Message = "No se encontro el código";
                }


            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = "Internal server error";
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        [HttpPost("UpdateUser", Name = "UpdateUser")]
        public ActionResult<ApiResponse<Users>> UpdateUser([FromBody] UsersService user)
        {
            string filePath = string.Empty;
            Users model = new Users();
            byte[] imageBytes;
            var nombreArchivo = Guid.NewGuid();
            string pathFileFinal = string.Empty;

            EmailService _serviceEmail = new EmailService();
            Email modelEmail = new Email();

            var response = new ApiResponse<Users>();

            try
            {

                var usermodel = _userRepository.Find(c => c.Id == user.Id);


                if (!string.IsNullOrEmpty(user.imageAvatar))
                {
                    

                        user.imageAvatar = user.imageAvatar.Replace("data:image/jpeg;base64,", "");

                        imageBytes = Convert.FromBase64String(user.imageAvatar);

                        if (imageBytes.Length > 0)
                        {

                            filePath = Path.Combine(_hostingEnv.ContentRootPath, "perfiles", nombreArchivo.ToString() + ".png");

                            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                fileStream.Write(imageBytes, 0, imageBytes.Length);
                            }

                        }


                        Uri baseUri = new Uri(filePath);

                        pathFileFinal = baseUri.AbsoluteUri.Replace("file:///C:", "http:/");
                    
                }


                if (user.imageAvatar != "")
                {
                    model.Avatar = pathFileFinal;
                }
                else
                {
                    model.Avatar = usermodel.Avatar;
                }




                model.Active = true;

                model.BirthDate = user.BirthDate;
                model.CreatedBy = 0;
                model.CreatedDate = DateTime.Now;
                model.Email = user.Email;
                model.GenderId = user.GenderId;
                model.Id = user.Id;
                model.Name = user.Name;
                model.Password = usermodel.Password;
                model.ProfessionalLicense = user.ProfessionalLicense;
                model.SpecialtyId = user.SpecialtyId;
                model.Token = string.Empty;
                model.UpdateBy = 0;
                model.UpdatedDate = DateTime.Now;
                model.Verified = user.Verified;
                model.VerificationCode = usermodel.VerificationCode;
                


                Users usuario = _userRepository.Update(_mapper.Map<Users>(model), model.Id);
                response.Result = usuario;



            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = "Internal server error";
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, response);

            }

            return Ok(response);
        }


        [HttpPost("AddNewUserBackOffice", Name = "AddNewUserBackOffice")]
        public ActionResult<ApiResponse<Users>> AddNewUserBackOffice([FromBody] UsersService user)
        {
            string filePath = string.Empty;
            Users model = new Users();
            byte[] imageBytes;
            var nombreArchivo = Guid.NewGuid();
            string pathFileFinal = string.Empty;
            string aleatorio = string.Empty;
            EmailService _serviceEmail = new EmailService();
            Email modelEmail = new Email();

            var response = new ApiResponse<Users>();

            try
            {

                if (!string.IsNullOrEmpty(user.imageAvatar))
                {
                    //user.imageAvatar = user.imageAvatar.Replace("data:image/jpeg;base64,", "");

                    imageBytes = Convert.FromBase64String(user.imageAvatar);

                    if (imageBytes.Length > 0)
                    {

                        filePath = Path.Combine(_hostingEnv.ContentRootPath, "perfiles", nombreArchivo.ToString() + ".png");

                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            fileStream.Write(imageBytes, 0, imageBytes.Length);
                        }

                    }


                    Uri baseUri = new Uri(filePath);

                    pathFileFinal = baseUri.AbsoluteUri.Replace("file:///C:", "http:/");
                }



                //var hashed = _userRepository.HashPassword(user.Password);

                try
                {
                    aleatorio = GenerateRandom();
                }
                catch (Exception ex)
                {
                    aleatorio = GenerateRandom();
                }


                model.Active = true;
                model.Avatar = pathFileFinal;
                model.BirthDate = user.BirthDate;
                model.CreatedBy = 0;
                model.CreatedDate = DateTime.Now;
                model.Email = user.Email;
                model.GenderId = user.GenderId;
                model.Id = user.Id;
                model.Name = user.Name;
                model.Password = user.Password;
                model.ProfessionalLicense = user.ProfessionalLicense;
                model.SpecialtyId = user.SpecialtyId;
                model.Token = string.Empty;
                model.UpdateBy = 0;
                model.UpdatedDate = DateTime.Now;
                model.VerificationCode = aleatorio;
                model.Verified = false;


                if (_userRepository.Exists(c => c.Email == user.Email))
                {
                    response.Success = false;
                    response.Message = $"Email: { user.Email } Already Exists";
                    return BadRequest(response);
                }

                Users users = _userRepository.Add(_mapper.Map<Users>(model));
                response.Result = users;


                modelEmail.To = model.Email;
                modelEmail.Subject = "Verificación de cuenta";
                modelEmail.IsBodyHtml = true;
                modelEmail.Body = "Codigo de verificación de tu cuenta:<br><b>" + aleatorio + "</b>";
                _serviceEmail.SendEmail(modelEmail);



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


        [HttpPost("AddNewUser", Name = "AddNewUser")]
        public ActionResult<ApiResponse<Users>> AddNewUser([FromBody] UsersService user)
        {
            string filePath = string.Empty;
            Users model = new Users();
            byte[] imageBytes;
            var nombreArchivo = Guid.NewGuid();
            string pathFileFinal = string.Empty;
            string aleatorio = string.Empty;
            EmailService _serviceEmail = new EmailService();
            Email modelEmail = new Email();

            var response = new ApiResponse<Users>();

            try
            {

                if (!string.IsNullOrEmpty(user.imageAvatar))
                {
                    user.imageAvatar = user.imageAvatar.Replace("data:image/jpeg;base64,", "");

                    imageBytes = Convert.FromBase64String(user.imageAvatar);

                    if (imageBytes.Length > 0)
                    {

                        filePath = Path.Combine(_hostingEnv.ContentRootPath, "perfiles", nombreArchivo.ToString() + ".png");

                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            fileStream.Write(imageBytes, 0, imageBytes.Length);
                        }

                    }


                    Uri baseUri = new Uri(filePath);

                    pathFileFinal = baseUri.AbsoluteUri.Replace("file:///C:", "http:/");
                }



                //var hashed = _userRepository.HashPassword(user.Password);

                try
                {
                    aleatorio = GenerateRandom();
                }
                catch (Exception ex)
                {
                    aleatorio = GenerateRandom();
                }


                model.Active = true;
                model.Avatar = pathFileFinal;
                model.BirthDate = user.BirthDate;
                model.CreatedBy = 0;
                model.CreatedDate = DateTime.Now;
                model.Email = user.Email;
                model.GenderId = user.GenderId;
                model.Id = user.Id;
                model.Name = user.Name;
                model.Password = user.Password;
                model.ProfessionalLicense = user.ProfessionalLicense;
                model.SpecialtyId = user.SpecialtyId;
                model.Token = string.Empty;
                model.UpdateBy = 0;
                model.UpdatedDate = DateTime.Now;
                model.VerificationCode = aleatorio;
                model.Verified = false;


                if (_userRepository.Exists(c => c.Email == user.Email))
                {
                    response.Success = false;
                    response.Message = $"Email: { user.Email } Already Exists";
                    return BadRequest(response);
                }

                Users users = _userRepository.Add(_mapper.Map<Users>(model));
                response.Result = users;


                modelEmail.To = model.Email;
                modelEmail.Subject = "Verificación de cuenta";
                modelEmail.IsBodyHtml = true;
                modelEmail.Body = "Codigo de verificación de tu cuenta:<br><b>" + aleatorio + "</b>";
                _serviceEmail.SendEmail(modelEmail);



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




        [HttpGet("GenerateRandom", Name = "GenerateRandom")]
        public System.String GenerateRandom()
        {
            System.Random randomGenerate = new System.Random();
            System.String sPassword = "";
            sPassword = System.Convert.ToString(randomGenerate.Next(00000001, 99999999));
            return sPassword.Substring(sPassword.Length - 8, 8);
        }

        [HttpPost]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<UserDto>> Create(UserCreateDto item)
        {
            var response = new ApiResponse<UserDto>();

            try
            {
                if (_userRepository.Exists(c => c.Email == item.Email))
                {
                    response.Success = false;
                    response.Message = $"Email: { item.Email } Already Exists";
                    return BadRequest(response);
                }

                Users user = _userRepository.Add(_mapper.Map<Users>(item));
                response.Result = _mapper.Map<UserDto>(user);

                //response.Result = _userRepository.Add(_mapper.Map<User>(item));
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, response);
            }

            return StatusCode(201, response);
        }

        [HttpPost("Login", Name = "Login")]
        public ActionResult<ApiResponse<Users>> Login(string email, string password)
        {
            var response = new ApiResponse<Users>();

            try
            {
                var _user = _mapper.Map<Users>(_userRepository.Find(c => c.Email == email && c.Active == true));

                if (_user != null)
                {


                    if (_userRepository.VerifyPassword(_user.Password, password)) {

                        response.Result = _mapper.Map<Users>(_user);
                        //response.Result.Token = _userRepository.BuildToken(_user);
                        response.Success = true;
                        response.Message = "success";
                    }
                }
                else
                {
                    response.Success = true;
                    response.Result.Token = null;
                    response.Message = "Usuario y/o contraseña incorrecta";

                }

            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = "Internal server error";
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, response);
            }

            return Ok(response);
        }


        [HttpPost("UpdatePassword", Name = "UpdatePassword")]
        public ActionResult<ApiResponse<bool>> UpdatePassword(int userId,string password,string newPassword)
        {

            var response = new ApiResponse<bool>();

            try
            {
                var _user = _mapper.Map<Users>(_userRepository.Find(c => c.Id == userId));

                if(_user != null)
                {
                    var concide = _userRepository.VerifyPassword(_user.Password,password);

                    if(concide)
                    {
                        var passwordNew = _userRepository.HashPassword(newPassword);

                        _user.Password = passwordNew;
                        Users users = _userRepository.Update(_mapper.Map<Users>(_user), _user.Id);

                        response.Success = true;
                        response.Result = true;
                    }
                    else
                    {
                        response.Success = false;
                        response.Result = false;
                        response.Message = "El password actual no coincide con el registrado por el usuario";

                    }


                }
                else
                {
                    response.Success = false;
                    response.Result = false;
                    response.Message = "El usuario no existe";

                }


            }
            catch(Exception ex)
            {
                response.Result = false;
                response.Success = false;
                response.Message = "Internal server error";
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, response);
            }

            return Ok(response);

        }

        [HttpPost("RecoverPassword", Name = "RecoverPassword")]
        public ActionResult<ApiResponse<bool>> RecoverPassword(string email)
        {

            string PasswordAleatorio = string.Empty;
            EmailService _serviceEmail = new EmailService();
            Email modelEmail = new Email();

            var response = new ApiResponse<bool>();

            try
            {
                var _user = _mapper.Map<Users>(_userRepository.Find(c => c.Email == email));

                if (_user != null)
                {
                    try
                    {

                        PasswordAleatorio = GenerateRandom();
                    }
                    catch (Exception ex)
                    {
                        PasswordAleatorio = GenerateRandom();
                    }

                    _user.Password = _userRepository.HashPassword(PasswordAleatorio);

                    Users users = _userRepository.Update(_mapper.Map<Users>(_user), _user.Id);

                    if (users != null)
                    {
                        modelEmail.To = email;
                        modelEmail.Subject = "Recuperaciòn de contraseña";
                        modelEmail.IsBodyHtml = true;
                        modelEmail.Body = "Generamos esta nueva contrase&ntilde;a para ti, en cualquier momento puedes modificarla<br> en la secci&oacute;n <b>Reestablecer contrase&ntilde;a, en Guerreros App</b>, la contraseña generada es :<br><b>" + PasswordAleatorio + "</b>";
                        _serviceEmail.SendEmail(modelEmail);

                        response.Success = true;
                        response.Result = true;
                        response.Message = "El email fue enviado";
                    }
                }
                else
                {
                    response.Success = true;
                    response.Result = false;
                    response.Message = "El email no esta registrado";

                }

            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Success = false;
                response.Message = "Internal server error";
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<UserDto>> Update(int id, UserUpdateDto item)
        {
            var response = new ApiResponse<UserDto>();

            try
            {
                //var user = _userRepository.Find(c => c.Id == id);

                //if (user != null)
                //{
                //    response.Message = $"User id { id } Not Found";
                //    return NotFound(response);
                //}


                _userRepository.Update(_mapper.Map<Users>(item), 32);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = "Internal server error";
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<ApiResponse<UserDto>> Delete(int id)
        {
            var response = new ApiResponse<UserDto>();

            try
            {
                var user = _userRepository.Find(c => c.Id == id);

                if (user == null)
                {
                    response.Message = $"User id { id } Not Found";
                    return NotFound(response);
                }

                _userRepository.Delete(user);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = "Internal server error";
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, response);
            }

            return Ok(response);
        }
    }
}
