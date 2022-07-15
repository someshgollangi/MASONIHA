using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.Entities
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderModel { get; set; }
        public int OrderDiscount { get; set; }
        public int OrderPrice { get; set; }
    }
}
