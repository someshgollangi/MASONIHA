using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ShoppingCore.Entities
{
    public class Context : DbContext
    {
        public Context() : base("OnlineShoppingEntities")
        {

        }
        public DbSet<Products> products { get; set; }
        public DbSet<SubCategories> subCategories { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<User_tbl> user_Tbls { get; set; }
        public DbSet<Role_tbl> role_Tbls { get; set; }
    }
}
