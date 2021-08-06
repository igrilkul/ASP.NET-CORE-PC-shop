using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PCShop.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private PCShopDbContext data;

        public AdminController(
            PCShopDbContext data)
        {
            this.data = data;
        }

        public IActionResult All()
        {
            if (!this.User.IsInRole("Administrator"))
            {
                return BadRequest();
            }
            else
            {
                return View();
            }
            
        }

        private string GetUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            return currentUserId;
        }
    }
}
