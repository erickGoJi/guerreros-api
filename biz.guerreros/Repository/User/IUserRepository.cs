using biz.guerreros.Entities;
using biz.guerreros.Models.Email;
using biz.guerreros.Models.Users;
using System.Collections.Generic;

namespace biz.guerreros.Repository
{
    public interface IUserRepository : IGenericRepository<biz.guerreros.Entities.Users>
    {
        string HashPassword(string password);
        bool VerifyPassword(string hash, string password);
        string BuildToken(biz.guerreros.Entities.Users user);

        List<usuarioMedico> GetUsersByFilter(string fechaInicial, string FechaFinal, int specialityId, string name);

        List<ddlMedicos> GetDDLMedicos();

        UsersService GetUsuarioById(int id);






    }
}
