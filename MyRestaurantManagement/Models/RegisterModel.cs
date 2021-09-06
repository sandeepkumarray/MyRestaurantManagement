using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManagement.Models
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(otherProperty: "Password", ErrorMessage = "Password & Confirm Password does not match")]
        public string ConfirmPassword { get; set; }

        public RegisterModel()
        {

        }

        public RegisterModel(string _FirstName, string _LastName, string _Username, string _Password)
        {
            FirstName = _FirstName;
            LastName = _LastName;
            Username = _Username;
            Password = _Password;

        }
    }
}
