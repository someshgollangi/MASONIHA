using ShoppingCore.BaseInterfaces;
using ShoppingCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryImplementation
{
    public class ItemRepository : Repository<SubCategories>, IItemRepository
    {
        private Context cd;
        public ItemRepository()
        {
            cd = new Context();
        }
        public IEnumerable<SubCategories> GetSubCategories(int pid)
        {
            List<SubCategories> temp = new List<SubCategories>();
            foreach (var x in cd.subCategories)
            {
                if (x.Productid == pid)
                    temp.Add(x);
            }
            return temp;

        }

        public IEnumerable<SubCategories> Search(string name)
        {
            List<SubCategories> temp = new List<SubCategories>();
            foreach (var x in cd.subCategories)
            {
                if (x.ItemModel.ToLower().Contains(name.ToLower()))
                    temp.Add(x);
            }
            return temp;

        }
    }
}

