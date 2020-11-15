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
        }


        public ActionResult SignIn(AppUser user)
        {
            if (ModelState.IsValid)
            {
                AuthRepository authRepository = new AuthRepository();
                AppUser response = authRepository.SignIn(user.UserName, user.Password);
                if (response != null)
                {
                    Session["userId"] = response.Id;
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Welcome");
            }
            return RedirectToAction("Welcome");
        }

        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("Welcome");
        }
    }
}