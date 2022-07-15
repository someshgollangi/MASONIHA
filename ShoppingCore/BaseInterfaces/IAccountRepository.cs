using ShoppingCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.BaseInterfaces
{
    public interface IAccountRepository:IRepository<User_tbl>
    {
        User_tbl Register(User_tbl user);
        User_tbl Login(User_tbl user);
    }
}
