using MakeAWish.Data;
using MakeAWish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MakeAWish.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ToDoContext _dbContext;

        //public AuthRepository(ToDoContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public AppUser SignIn(string userName, string password)
        {
            using (var context = new ToDoContext())
            {
                var user = context.AppUser.Where(u => u.UserName == userName && u.Password == password).SingleOrDefault();
                return user;
            }
        }
    }
}