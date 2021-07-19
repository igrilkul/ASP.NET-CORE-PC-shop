using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using PCShop.Models.CPUCoolers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Controllers
{
    public class CPUCoolersController:Controller
    {
        private readonly PCShopDbContext data;

        public CPUCoolersController(
            PCShopDbContext data)
        {
            this.data = data;
        }

        public IActionResult All()
        {
            var CPUCoolers = this.data
                 .CPUCoolers
                 .OrderByDescending(c => c.Id)
                 .Select(c => new CPUCoolersListViewModel
                 {
                     Id = c.Id,
                     ImagePath = c.ImagePath,
                     Make = c.Make,
                     Model = c.Model,
                     Price = c.Price
                 })
                 .ToList();

            return View(CPUCoolers);
        }
    }
}
