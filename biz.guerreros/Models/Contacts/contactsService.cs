using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.Contacts
{
    public class contactsService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public string ContactType { get; set; }
    }
}
