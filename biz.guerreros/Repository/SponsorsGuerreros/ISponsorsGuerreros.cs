using biz.guerreros.Models.SponsorsGuerreros;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.SponsorsGuerreros
{
    public interface ISponsorsGuerreros:IGenericRepository<biz.guerreros.Entities.SponsorsGuerreros>
    {
         SponsorsGuerrerosService GetSponsorsGuerreros();
    }
}
