using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.Entities
{
    public class Products
    {
        [Key]
        public int Productid { get; set; }
        public string Productname { get; set; }

        public string Productimage { get; set; }
    }
}
