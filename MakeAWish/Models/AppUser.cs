using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MakeAWish.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "User name is required.")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        //ToDo: Password hash and salt insetad of plain password

        //public string PasswordHash { get; set; }
        //public string PasswordSalt { get; set; }
        //public string EmailId { get; set; }
    }
}