using ShoppingCore.BaseInterfaces;
using ShoppingCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.BaseInterfaces
{
    public interface IItemRepository:IRepository<SubCategories>
    {
        IEnumerable<SubCategories> GetSubCategories(int pid);
        IEnumerable<SubCategories> Search(string name);

    }
}
