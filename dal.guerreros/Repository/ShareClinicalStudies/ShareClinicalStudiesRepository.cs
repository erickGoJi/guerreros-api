using biz.guerreros.Repository.ShareClinicalStudies;
using dal.guerreros.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal.guerreros.Repository.ShareClinicalStudies
{
    public class ShareClinicalStudiesRepository: GenericRepository<biz.guerreros.Entities.ShareClinicalStudies>, IShareClinicalStudies
    {
        public ShareClinicalStudiesRepository(Db_GuerrerosContext context) : base(context) { }
    }
}
