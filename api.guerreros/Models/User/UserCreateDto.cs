using System;
using System.ComponentModel.DataAnnotations;

namespace api.guerreros.Models
{
    public class UserCreateDto
    {
        public int Id { get; set; }
        public int SpecialtyId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Avatar { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        public string ProfessionalLicense { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
        public bool? Active { get; set; }
        public string Token { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
