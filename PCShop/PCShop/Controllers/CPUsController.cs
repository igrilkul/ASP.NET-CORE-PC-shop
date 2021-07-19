using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using PCShop.Models.CPUs;
using System.Linq;
using System;

namespace PCShop.Controllers
{
    public class CPUsController : Controller
    {
        private readonly PCShopDbContext data;

        public CPUsController(
            PCShopDbContext data)
        {
            this.data = data;
        }

        public IActionResult All(CPUSorting sorting, string platform, string searchTerm)
        {
            var cpusQuery = this.data.CPUs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(platform))
            {
                cpusQuery = cpusQuery.Where(c => c.Platform == platform);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                cpusQuery = cpusQuery.Where(c =>
                c.Platform.ToLower().Contains(searchTerm.ToLower())
                || c.Model.ToLower().Contains(searchTerm.ToLower())
                || (c.Platform + " " + c.Model).ToLower().Contains(searchTerm.ToLower()));
            }

            cpusQuery = sorting switch
            {
                CPUSorting.Price => cpusQuery.OrderByDescending(c => c.Price),
                CPUSorting.ReleasedYear => cpusQuery.OrderByDescending(c => c.ReleasedYear),
                CPUSorting.TDP => cpusQuery.OrderByDescending(c => c.TDP),
                _=>cpusQuery.OrderByDescending(c=>c.Id)
            };

            var cpus = cpusQuery
                 .Select(c => new CPUsListViewModel
                 {
                     Id = c.Id,
                     ImagePath = c.ImagePath,
                     Platform = c.Platform,
                     Model=c.Model,
                     BoostFrequencies=c.BoostFrequencies,
                     Price=c.Price,
                     TDP=c.TDP,
                     ReleasedYear=c.ReleasedYear
                 })
                 .ToList();

            var cpuPlatforms = this.data
                .CPUs
                .Select(c => c.Platform)
                .Distinct()
                .ToList();

            var cpusModel = new AllCPUsQueryModel
            {
                Sorting= sorting,
                Platforms = cpuPlatforms,
                CPUs = cpus,
                SearchTerm = searchTerm
            };

            

            return View(cpusModel);
        }
    }
}
