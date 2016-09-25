using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssistModule.Extensions;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatService.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            if (UserAction.ValidateToken(this))
            {
                int userId = (int)HttpContext.Items[SessionType.AccountId];

                var user = Data.DataContext.Instance.Accounts.First(x => x.Id == userId);

                if (user != null)
                {
                    ViewData["Title"] = user.DisplayName + "'s profile";
                    return View(user);
                }
                else
                {
                    // Dispose Sessions
                    HttpContext.Items.Clear();
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Items.Clear();
            return View();
        }
    }
}
