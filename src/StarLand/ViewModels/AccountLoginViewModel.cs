using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StarLand.ViewModels
{
    public class AccountLoginViewModel
    {
        [Required, MaxLength(256)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        //Flag indicating whether the sign-in cookie should persist after the browser is closed.
        //public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
