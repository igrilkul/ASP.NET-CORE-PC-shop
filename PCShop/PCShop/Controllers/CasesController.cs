using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using PCShop.Models.Cases;
using System.Linq;


namespace PCShop.Controllers
{
    public class CasesController:Controller
    {
        private readonly PCShopDbContext data;

        public CasesController(
            PCShopDbContext data)
        {
            this.data = data;
        }
        public IActionResult All()
        {
            var cases = this.data
                .Cases
                .OrderByDescending(c=>c.Id)
                .Select(c => new CasesListViewModel
                {
                    Id = c.Id,
                    ImagePath = c.ImagePath,
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    Size = c.Size
                })
                .ToList();

            return View(cases);
        }
    }
}
