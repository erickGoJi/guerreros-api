using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.ContactGuerreros
{
    public class contactGuerrerosService
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Instagram { get; set; }

        public string Facebook { get; set; }

        public string twitter { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
