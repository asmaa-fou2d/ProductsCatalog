using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using ProductsCatalog.Data;
using ProductsCatalog.Data.Entities;
using ProductsCatalog.Website.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProductsCatalog.Website.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {

            var userStore = new UserStore<User>(new ProductsCatalogContext());
            var manager = new UserManager<User>(userStore);

            if (ModelState.IsValid)
            {
                var user = await manager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                  //  var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, userIdentity);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
        
        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}