using MakeAWish.Models;
using MakeAWish.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MakeAWish.Controllers
{
    public class AuthController : Controller
    {
        // GET: Users
        public ActionResult Welcome()
        {
            if (Session["userId"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            // return View();

        }


        public ActionResult SignIn(AppUser user)
        {
            AuthRepository authRepository = new AuthRepository();
            AppUser response = authRepository.SignIn(user.UserName, user.Password);
            if (user != null)
            {
                Session["userId"] = response.Id;
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Welcome");
        }
    }
}