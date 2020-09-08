using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Logging;
using GameStoreDAL;
using System.Data.Entity;

[assembly: OwinStartup(typeof(GameStoreClietUI.Startup))]

namespace GameStoreClietUI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<DbContext>(()=>new AplicationContext());


            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath=new PathString("/Auth/Login")
            });
        }
    }
}
