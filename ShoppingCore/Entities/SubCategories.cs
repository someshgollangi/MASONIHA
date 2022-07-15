using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.Entities
{
    public class SubCategories
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemModel { get; set; }
        public int ItemDiscount { get; set; }
        public int ItemPrice { get; set; }
        public string Specification { get; set; }
        public string Iimage { get; set; }
        public int Productid { get; set; }
        public Products Products { get; set; }
    }
}
