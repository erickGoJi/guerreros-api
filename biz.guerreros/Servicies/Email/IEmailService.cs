using biz.guerreros.Models.Email;

namespace biz.guerreros.Servicies
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}
