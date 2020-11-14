using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeAWish.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string EmailId { get; set; }
    }
}