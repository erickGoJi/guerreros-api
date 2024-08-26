using biz.guerreros.Models.ContactGuerreros;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.ContactGuerreros
{
    public interface IcontactGuerreros:IGenericRepository<biz.guerreros.Entities.ContactGuerreros>
    {
        contactGuerrerosService GetContactGuerreros();
    }
}
