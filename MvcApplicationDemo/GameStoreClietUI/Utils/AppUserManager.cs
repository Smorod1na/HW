using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameStoreClietUI.Utils
{
    public class AppUserManager:UserManager<IdentityUser>
    {
        public AppUserManager(IUserStore<IdentityUser> store):base(store)
        {

        }
        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> option,IOwinContext owinContext)
        {
            var dbcontext = owinContext.Get<DbContext>();
            var manager = new AppUserManager(new UserStore<IdentityUser>(dbcontext));

            manager.UserValidator = new UserValidator<IdentityUser>(manager)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames=true
            };
            manager.PasswordValidator = new PasswordValidator
            {
                RequireDigit = true,
                RequireLowercase=true,
                RequiredLength=5,
                //symbol
                RequireNonLetterOrDigit=true
            };
                return manager;
        }
    }
}