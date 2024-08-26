using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.InformationGuerreros
{
    public class informationGuerrerosService
    {
        public int Id { get; set; }

        public string about { get; set; }

        public string NoticePrivacy { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
