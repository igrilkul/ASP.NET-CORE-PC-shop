using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PCShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Controllers
{
    public class HomeController : Controller
    {
        //[AutoValidateAntiforgeryToken]
        public IActionResult Index()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
