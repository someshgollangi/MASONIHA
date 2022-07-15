using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCore.BaseInterfaces;
using ShoppingCore.Entities;

namespace RepositoryImplementation
{
    public class OrdersRepository:Repository<Orders>,IOrdersRepository
    {
        private Context cd;
        public OrdersRepository()
        {
            cd = new Context();
        }

        public Orders AddToCart(int id)
        {
            var e = cd.subCategories.Where(x => x.ItemId == id).Single();
            Orders o = new Orders { OrderModel = e.ItemModel, OrderDiscount = e.ItemDiscount, OrderPrice = e.ItemPrice };

            //cd.orders.Add(o);
            //cd.SaveChanges();
            return o;
        }

        public void ConfirmCheckout()
        {
            foreach (var x in cd.orders)
                cd.orders.Remove(x);
            cd.SaveChanges();
        }
    }
}
