using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using WebProjectR.Models;

namespace WebProjectR
{
    public class CustomUserValidator : UserValidator<ApplicationUser>
    {
        public CustomUserValidator(ApplicationUserManager mgr)
            : base(mgr)
        {
            AllowOnlyAlphanumericUserNames = false;
            RequireUniqueEmail = true;
        }
        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            if (user.Email.ToLower().EndsWith("@spam.com"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Данный домен находится в спам-базе. Выберите другой почтовый сервис");
                result = new IdentityResult(errors);
            }

            if (user.UserName.Contains("admin"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Ник пользователя не должен содержать слово 'admin'");
                result = new IdentityResult(errors);
            }

            if (user.UserName.Length < 4)
            {
                var errors = result.Errors.ToList();
                errors.Add("Имя пользователя должно быть меньше 4 символов");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}