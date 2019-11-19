using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsPortal.Web.ViewModel
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Enter username.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [Compare("Password", ErrorMessage = "Password does not match.")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}