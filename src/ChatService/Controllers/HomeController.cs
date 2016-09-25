using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatService.Models;

namespace ChatService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(AccountTemplate model)
        {
            var user = model.Create();

            bool exist = Data.DataContext.Instance.Accounts.Any(x => x.Username == user.Username);

            if (!exist)
            {
                Data.DataContext.Instance.Accounts.Add(user);
                int row = Data.DataContext.Instance.SaveChanges();
                if (row == 1)
                {
                    return RedirectToAction("Preview", model);
                }
            }
            return View();
        }

        public IActionResult Preview(AccountTemplate user)
        {
            return View(user);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        private async void SaveAsync()
        {
            await Data.DataContext.Instance.SaveChangesAsync();
        }
    }
}
