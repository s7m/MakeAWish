using MakeAWish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeAWish.Repository
{
    interface IAuthRepository
    {
        AppUser SignIn(string userName, string password);
    }
}
