using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.Entities
{
    public class User_tbl
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "User Id is Required")]
        public string UserID { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Username is Required")]
        [StringLength(10, ErrorMessage = "Username Length must be between 4 and 10 characters", MinimumLength = 4)]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Display(Name = "MobileNumber")]
        [Required(ErrorMessage = "MobileNumber is Required")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNumber { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword")]
        [Required(ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role_tbl Role_Tbl { get; set; }
    }
}
