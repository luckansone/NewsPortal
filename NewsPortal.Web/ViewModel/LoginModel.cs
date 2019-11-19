using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsPortal.Web.ViewModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter username.")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Enter password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}