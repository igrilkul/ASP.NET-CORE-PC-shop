using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using PCShop.Models.PSUs;
using System.Linq;
using System;

using System.Threading.Tasks;
using PCShop.Models;

namespace PCShop.Controllers
{
    public class PSUsController : Controller
    {
        private readonly PCShopDbContext data;

        public PSUsController(
            PCShopDbContext data)
        {
            this.data = data;
        }

        public IActionResult All([FromQuery] AllPSUsQueryModel query)
        {
            var psusQuery = this.data.Products.Where(p => p.CategoryId == 6).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Make))
            {
                psusQuery = psusQuery.Where(c => c.Make == query.Make);
            }

            if (!string.IsNullOrWhiteSpace(query.Efficiency))
            {
                psusQuery = psusQuery.Where(c => c.Efficiency == query.Efficiency);
            }

            if (!(query.Power==null))
            {
                psusQuery = psusQuery.Where(c => c.Power == query.Power);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                psusQuery = psusQuery.Where(c =>
                c.Make.ToLower().Contains(query.SearchTerm.ToLower())
                || c.Model.ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Make + " " + c.Model).ToLower().Contains(query.SearchTerm.ToLower()));
            }

            psusQuery = query.Sorting switch
            {
                PSUSorting.ReleasedYear => psusQuery.OrderByDescending(c => c.ReleasedYear),
                PSUSorting.Price => psusQuery.OrderByDescending(c => c.Price),
                PSUSorting.Power => psusQuery.OrderByDescending(c => c.Power),
                PSUSorting.Efficiency => psusQuery.OrderByDescending(c => c.Efficiency),
                _ => psusQuery.OrderByDescending(c => c.Id)
            };

            var psus = psusQuery
                .Skip((query.CurrentPage - 1) * AllPSUsQueryModel.ItemsPerPage)
                .Take(AllPSUsQueryModel.ItemsPerPage)
                 .Select(c => new ProductListViewModel
                 {
                     Id = c.Id,
                     CategoryId = c.CategoryId,
                     ImagePath = c.ImagePath,
                     Make = c.Make,
                     Model = c.Model,
                     Price = c.Price,
                     Power = c.Power,
                     Efficiency = c.Efficiency
                 })
                 .ToList();

            var totalCount = psusQuery.Count();

            var psusPowers = this.data
                .Products.Where(p => p.CategoryId == 6)
                .Select(c => c.Power)
                .Distinct()
                .ToList();

            var psusMakes = this.data
                .Products.Where(p => p.CategoryId == 6)
                .Select(c => c.Make)
                .Distinct()
                .ToList();

            var psusEfficiencies = this.data
                .Products.Where(p => p.CategoryId == 6)
                .Select(c => c.Efficiency)
                .Distinct()
                .ToList();

            var psusModel = new AllPSUsQueryModel
            {
                Sorting = query.Sorting,
                Makes = psusMakes,
                Efficiencies = psusEfficiencies,
                Powers = psusPowers,
                PSUs = psus,
                SearchTerm = query.SearchTerm,
                CurrentPage = query.CurrentPage,
                TotalCount = totalCount,
                Make = query.Make
            };



            return View(psusModel);
        }

        public IActionResult Details(string id)
        {
            var psu = this.data.Products.Where(p => p.CategoryId == 6).Where(c => c.Id == Int32.Parse(id)).Select(c => new ProductDetailsViewModel
            {
                ImagePath = c.ImagePath,
                Make = c.Make,
                Model = c.Model,
                Efficiency = c.Efficiency,
                Power = c.Power,
                Price = c.Price,
                ReleasedYear = c.ReleasedYear
            }).FirstOrDefault();

            if (psu == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(psu);
        }
    }
}
