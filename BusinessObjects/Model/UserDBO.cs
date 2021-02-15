using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("User")]
    public class UserDBO
    {
        [Key]
        [Display(Name = "UserID")]
        [Required(ErrorMessage = "User ID is Required")]
        public int UserID { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [MinLength(5, ErrorMessage = "Minimum Password must be 5 in charaters")]
        [DataType(DataType.Password)]
        [RegularExpression("^.*(?=.*\\d)(?=.*[a-zA-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Password must contains one digit,one alphabet and one special character ")]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [Display(Name = "EmailID")]
        [RegularExpression("[^@]+@[^@]+\\.[^@]+$", ErrorMessage = "Please enter valid email address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "EmailId is Required")]
        public string EmailID { get; set; }

    }
}
