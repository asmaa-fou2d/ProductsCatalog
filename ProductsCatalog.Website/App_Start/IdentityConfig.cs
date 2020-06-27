using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using ProductsCatalog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsCatalog.Website.App_Start
{
    public static class IdentityConfig
    {
        public static void Configuration(IAppBuilder app)
        {
           // app.CreatePerOwinContext(() => new ProductsCatalogContext());
            //app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            //app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) =>
            //    new RoleManager<AppRole>(
            //        new RoleStore<AppRole>(context.Get<MyDbContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}