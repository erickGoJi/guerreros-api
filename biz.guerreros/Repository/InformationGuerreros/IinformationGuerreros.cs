using biz.guerreros.Models.InformationGuerreros;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.InformationGuerreros
{
    public interface IinformationGuerreros:IGenericRepository<biz.guerreros.Entities.InformationGuerreros>
    {
        informationGuerrerosService GetInformationGuerreros();
    }
}
