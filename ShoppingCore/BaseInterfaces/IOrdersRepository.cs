using ShoppingCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.BaseInterfaces
{
    public interface IOrdersRepository:IRepository<Orders>
    {
        Orders AddToCart(int id);
        void ConfirmCheckout();
    }
}
