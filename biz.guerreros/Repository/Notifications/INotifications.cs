using biz.guerreros.Models.ddlStudy;
using biz.guerreros.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Text;


namespace biz.guerreros.Repository.Notifications
{
    public interface INotifications:IGenericRepository<biz.guerreros.Entities.Notifications>
    {
        NotificationsService AddNewNotifications(biz.guerreros.Entities.Notifications notifications);

        List<ddlStudyService> GetDDLStudy();

    }
}
