using biz.guerreros.Entities;
using biz.guerreros.Repository;
using dal.guerreros.DBContext;
using CryptoHelper;
using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using biz.guerreros.Models.Email;
using System.Security.Cryptography;
using System.Linq;
using System.Collections.Generic;
using biz.guerreros.Models.Users;

namespace dal.guerreros.Repository
{
    public class UserRepository : GenericRepository<biz.guerreros.Entities.Users>, IUserRepository
    {
        private IConfiguration _config;

        public UserRepository(Db_GuerrerosContext context, IConfiguration config) : base(context) { _config = config; }

        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
            
        }

        public string BuildToken(biz.guerreros.Entities.Users user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
            
        }

        public override biz.guerreros.Entities.Users Add(biz.guerreros.Entities.Users user)
        {
            user.Password = HashPassword(user.Password);
            return base.Add(user);
        }

        public override biz.guerreros.Entities.Users Update(biz.guerreros.Entities.Users user, object id)
        {
            user.UpdatedDate = DateTime.Now;
            return base.Update(user, id);
        }

        public List<usuarioMedico> GetUsersByFilter(string fechaInicial, string FechaFinal, int specialityId, string name)
        {

            var service = _context.Users
                .Where(j => j.Active == true)
                .Where(b => b.CreatedDate.Value.Date >= Convert.ToDateTime(fechaInicial).Date && b.CreatedDate.Value.Date <= Convert.ToDateTime(FechaFinal).Date)
                .Where(k => specialityId == 0 || k.SpecialtyId == specialityId)
                .Where(k => string.IsNullOrEmpty(name)  || k.Name.Contains(name))
                .Select(i => new usuarioMedico
                {
                    verificado = i.Verified,
                    cedula = i.ProfessionalLicense,
                    correo = i.Email,
                    especialidad = i.Specialty.Name,
                    especialidadId = i.SpecialtyId,
                    fechaRegistro = i.CreatedDate,
                    nombre = i.Name,
                    avatar = i.Avatar.Replace("inetpub/wwwroot", "34.237.214.147"),
                    userId = i.Id







                }).ToList();

            return service;
            
        }

        public List<ddlMedicos> GetDDLMedicos()
        {
            var service = _context.Users
                .Select(i => new ddlMedicos
                {
                    Id = i.Id,
                    nombreMedico = i.Name


                }).ToList();

            return service;
        }

        public UsersService GetUsuarioById(int id)
        {
            var service = _context.Users
                .Where(x => x.Id == id)
                .Select(i => new UsersService
                {
                    Id = i.Id,
                    Avatar = i.Avatar.Replace("inetpub/wwwroot", "34.237.214.147"),
                    Name = i.Name,
                    BirthDate = i.BirthDate,
                    GenderId = i.GenderId,
                    ProfessionalLicense = i.ProfessionalLicense,
                    Email = i.Email,
                    Password = i.Password,
                    imageAvatar = "",
                    SpecialtyId = i.SpecialtyId



                }).FirstOrDefault();

            return service;
                
        }
    }
}
