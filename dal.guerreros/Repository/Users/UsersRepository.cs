using biz.guerreros.Repository.Users;
using dal.guerreros.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal.guerreros.Repository.Users
{
    public class UsersRepository:GenericRepository<biz.guerreros.Entities.Users>,IUsers
    {
        public UsersRepository(Db_GuerrerosContext context) : base(context) { }
    }
}
