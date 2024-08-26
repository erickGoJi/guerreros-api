using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.Notifications
{
    public class NotificationsService
    {
        public int Id { get; set; }
        public int CliniciansStudiesId { get; set; }
        public string AgeRange { get; set; }
        public int StudyTypeId { get; set; }
        public string Token { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
