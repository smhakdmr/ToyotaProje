using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Toyota.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Index(User user)
        //{
        //    Context context = new Context();
        //    var data = context.Users.FirstOrDefault(a => a.Email == user.Email && a.Password == user.Password);
        //    if (data != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, user.Email)
        //        };
        //        var userIdentity = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Index", "Service");
        //    }
        //    else
        //        return View();
        //}
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {

            Context context = new Context();
            var data = context.Users.FirstOrDefault(a => a.Email == user.Email && a.Password == user.Password);
            if (data != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email)
                };
                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return Json(new { success = true, redirectUrl = Url.Action("Index", "Service") });
            }
            else
            {
                return Json(new { success = false });
            }
        }

    }
}
