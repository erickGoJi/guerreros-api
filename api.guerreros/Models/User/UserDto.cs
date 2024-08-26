using System;

namespace api.guerreros.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public int SpecialtyId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        public string ProfessionalLicense { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? Active { get; set; }
        public string Token { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
