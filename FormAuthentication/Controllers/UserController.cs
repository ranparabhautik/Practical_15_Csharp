using FormAuthentication.Models.Context;
using FormAuthentication.Models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

namespace FormAuthentication.Controllers
{
    public class UserController : Controller
    {
        AppDBContext context = new AppDBContext();
        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users user)
        {
            var data = context.users.FirstOrDefault(x => x.username == user.username && x.password == user.password);
            if(data != null)
            {
                FormsAuthentication.SetAuthCookie(user.username, false);
                return RedirectToAction("Index", "User");
            }
            ModelState.AddModelError("", "Invalid credentials");
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Users model)
        {
            context.users.Add(model);
            context.SaveChanges();

            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}