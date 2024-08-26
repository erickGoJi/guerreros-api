using biz.guerreros.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.Contacts
{
    public interface IContacts:IGenericRepository<biz.guerreros.Entities.Contacts>
    {
        List<contactsService> GetAllContacts();
    }
}
