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
            if (model.SetPassword())
            {
                Account user = model as Account;
                Data.DataContext.Instance.Accounts.Add(user);
                int rows = Data.DataContext.Instance.SaveChanges();

                if (rows == 1)
                {
                    return RedirectToAction("Preview", model);
                }
                else
                {
                    ViewBag.Message = "Username is already exists";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Password is not match";
                return View();
            }
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
