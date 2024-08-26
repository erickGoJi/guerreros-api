using biz.guerreros.Models.ddlStudy;
using biz.guerreros.Models.Notifications;
using biz.guerreros.Repository.Notifications;
using dal.guerreros.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.guerreros.Repository.Notifications
{
    public class NotificationsRepository : GenericRepository<biz.guerreros.Entities.Notifications>, INotifications
    {

        public NotificationsRepository(Db_GuerrerosContext context) : base(context) { }
        public NotificationsService AddNewNotifications(biz.guerreros.Entities.Notifications notifications)
        {
            throw new NotImplementedException();
        }

        public List<ddlStudyService> GetDDLStudy()
        {
            var service = _context.StudyCategory
                .Select(i => new ddlStudyService
                {
                    Id = i.Id,
                    Name = i.Name
                }).ToList();


            return service;
        }
    }
}
