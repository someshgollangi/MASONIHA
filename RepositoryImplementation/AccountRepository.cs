using ShoppingCore.BaseInterfaces;
using ShoppingCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryImplementation
{
    public class AccountRepository : Repository<User_tbl>, IAccountRepository
    {
        private Context cd;
        public AccountRepository()
        {
            cd = new Context();
        }

        public User_tbl Login(User_tbl user)
        {
            User_tbl userexisting = null;
            userexisting = cd.user_Tbls
            .Where(u => u.UserID == user.UserName && u.Password == user.Password)
            .FirstOrDefault();
            return userexisting;
        }

        public User_tbl Register(User_tbl user)
        {
                user.RoleId = 2;
                return user;
        }
    }
}
