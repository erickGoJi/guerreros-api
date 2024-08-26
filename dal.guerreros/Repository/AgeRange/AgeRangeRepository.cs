using biz.guerreros.Entities;
using biz.guerreros.Repository.AgeRange;
using dal.guerreros.DBContext;

namespace dal.guerreros.Repository.AgeRange
{
    public class AgeRangeRepository : GenericRepository<CatAgeRange>, IAgeRangeRepository
    {
        public AgeRangeRepository(Db_GuerrerosContext context) : base(context)
        {
            
        }
    }
}