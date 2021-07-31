using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using PCShop.Models.CPUs;
using System.Linq;
using System;
using PCShop.Models;

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

        public IActionResult All([FromQuery]AllCPUsQueryModel query)
        {
            var cpusQuery = this.data.Products.Where(p=>p.CategoryId==2).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Platform))
            {
                cpusQuery = cpusQuery.Where(c => c.Platform == query.Platform);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                cpusQuery = cpusQuery.Where(c =>
                c.Platform.ToLower().Contains(query.SearchTerm.ToLower())
                || c.Model.ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Platform + " " + c.Model).ToLower().Contains(query.SearchTerm.ToLower()));
            }

            cpusQuery = query.Sorting switch
            {
                CPUSorting.Price => cpusQuery.OrderByDescending(c => c.Price),
                CPUSorting.ReleasedYear => cpusQuery.OrderByDescending(c => c.ReleasedYear),
                _=>cpusQuery.OrderByDescending(c=>c.Id)
            };

            var cpus = cpusQuery
                .Skip((query.CurrentPage-1) * AllCPUsQueryModel.CPUsPerPage)
                .Take(AllCPUsQueryModel.CPUsPerPage)
                 .Select(c => new ProductListViewModel
                 {
                     Id = c.Id,
                     CategoryId = c.CategoryId,
                     ImagePath = c.ImagePath,
                     Platform = c.Platform,
                     Model=c.Model,
                     Price=c.Price,
                     ReleasedYear=c.ReleasedYear
                 })
                 .ToList();

            var cpusCount = cpusQuery.Count();

            var cpuPlatforms = this.data
                .Products.Where(p => p.CategoryId == 2)
                .Select(c => c.Platform)
                .Distinct()
                .ToList();

            var cpusModel = new AllCPUsQueryModel
            {
                Sorting= query.Sorting,
                Platforms = cpuPlatforms,
                CPUs = cpus,
                SearchTerm = query.SearchTerm,
                CurrentPage = query.CurrentPage,
                TotalCPUs = cpusCount,
                Platform = query.Platform
            };

            

            return View(cpusModel);
        }

        public IActionResult Details(string id)
        {
            int idInt = Int32.Parse(id);
            var cpu = this.data.Products.Where(p => p.CategoryId == 2).Where(c => c.Id == Int32.Parse(id)).Select(c => new CPUDetailsViewModel
            {
                ImagePath = c.ImagePath,
                Platform = c.Platform,
                Model = c.Model,
                MinSpeed = c.MinSpeed,
                MaxSpeed = c.MaxSpeed,
                TDP = c.TDP,
                Price = c.Price,
                ReleasedYear = c.ReleasedYear
            }).FirstOrDefault();

            if(cpu == null)
            {
                return BadRequest();
            }

            return View(cpu);
        }
    }
}
