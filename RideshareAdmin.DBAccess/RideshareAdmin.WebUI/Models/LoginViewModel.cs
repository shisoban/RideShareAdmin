using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RideshareAdmin.WebUI.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        //Validate the user logon
        public bool IsValid(string _username, string _password)
        {
            return true;
        }
    }
}