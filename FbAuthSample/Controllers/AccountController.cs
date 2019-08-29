using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace FbAuthSample.Controllers
{
    public class AccountController : Controller
    {
        public Task SignIn()
        {
            return HttpContext.ChallengeAsync(FacebookDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = "/"
            });
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}