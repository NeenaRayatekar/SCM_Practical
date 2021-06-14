using NotesApp.Context;
using NotesApp.Models;
using NotesApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NotesApp.Controllers
{
    [Repository.ApplicationException]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(NotesApp.Models.UserDetails model)
        {
            ILogin login = new LoginRepository();
            bool isValid = login.Userlogin(model);
            if (isValid)
            {
                return RedirectToAction("Index", "Notes");
            }
            ModelState.AddModelError("", "Invalid username and password");
            return View();            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}