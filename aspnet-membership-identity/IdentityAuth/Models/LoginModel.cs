using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityAuth.Models
{
    public class LoginModel
    {
        [Display(Name = "Login")]
        public String Login { get; set; }

        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}