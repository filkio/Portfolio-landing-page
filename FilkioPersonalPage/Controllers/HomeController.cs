using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FilkioPersonalPage.Models;

namespace FilkioPersonalPage.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("main");
        }
        public ViewResult contact()
        {
            return View();
        }
        public ViewResult aboutme()
        {
            return View();
        }
        [HttpGet]
        public ViewResult subscribe()
        {
            return View();
        }
        [HttpPost]
        public ViewResult subscribe(SubResponce subResponce)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(subResponce);
                return View("ty", subResponce);
            }
            else 
            {
                return View();
            }
        }
    }
}
