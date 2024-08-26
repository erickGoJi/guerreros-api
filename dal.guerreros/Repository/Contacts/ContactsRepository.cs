using biz.guerreros.Models.Contacts;
using biz.guerreros.Repository.Contacts;
using dal.guerreros.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.guerreros.Repository.Contacts
{
    public class ContactsRepository : GenericRepository<biz.guerreros.Entities.Contacts>, IContacts
    {

        public ContactsRepository(Db_GuerrerosContext context) : base(context) { }
        public List<contactsService> GetAllContacts()
        {
            var service = _context.Contacts
                .Select(e => new contactsService
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Phone = e.Phone,
                    RegistrationDate = e.RegistrationDate,
                    ContactType = e.ContactType

                }).ToList();

            return service;
        }
    }
}
