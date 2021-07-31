using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using PCShop.Models;
using PCShop.Models.RAMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Controllers
{
    public class RAMsController : Controller
    {
        private readonly PCShopDbContext data;

        public RAMsController(
            PCShopDbContext data)
        {
            this.data = data;
        }

        public IActionResult All([FromQuery] AllRAMsQueryModel query)
        {
            var ramsQuery = this.data.Products.Where(p => p.CategoryId == 7).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Make))
            {
                ramsQuery = ramsQuery.Where(c => c.Make == query.Make);
            }

            if (!(query.Capacity == null))
            {
                ramsQuery = ramsQuery.Where(c => c.Capacity == query.Capacity);
            }

            if (!(query.MinSpeed == null))
            {
                ramsQuery = ramsQuery.Where(c => c.MinSpeed == query.MinSpeed);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                ramsQuery = ramsQuery.Where(c =>
                c.Make.ToLower().Contains(query.SearchTerm.ToLower())
                || c.Model.ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Make + " " + c.Model).ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Make + " " + c.Model + " " + c.Size).ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Make + " " + c.Capacity).ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Model + " " + c.Capacity).ToLower().Contains(query.SearchTerm.ToLower()));
            }

            ramsQuery = query.Sorting switch
            {
                RAMSorting.ReleasedYear => ramsQuery.OrderByDescending(c => c.ReleasedYear),
                RAMSorting.Price => ramsQuery.OrderByDescending(c => c.Price),
                RAMSorting.Capacity => ramsQuery.OrderByDescending(c => c.Capacity),
                RAMSorting.Speed => ramsQuery.OrderByDescending(c => c.MinSpeed),
                _ => ramsQuery.OrderByDescending(c => c.Id)
            };

            var rams = ramsQuery
                .Skip((query.CurrentPage - 1) * AllRAMsQueryModel.ItemsPerPage)
                .Take(AllRAMsQueryModel.ItemsPerPage)
                 .Select(c => new ProductListViewModel
                 {
                     Id = c.Id,
                     CategoryId = c.CategoryId,
                     ImagePath = c.ImagePath,
                     Make = c.Make,
                     Model = c.Model,
                     Price = c.Price,
                     Capacity = c.Capacity,
                     MinSpeed = c.MinSpeed
                 })
                 .ToList();

            var totalCount = ramsQuery.Count();

            var ramsSpeeds = this.data
                .Products.Where(p => p.CategoryId == 7)
                .Select(c => c.MinSpeed)
                .Distinct()
                .ToList();

            var ramsMakes = this.data
                .Products.Where(p => p.CategoryId == 7)
                .Select(c => c.Make)
                .Distinct()
                .ToList();

            var ramCapacities = this.data
                .Products.Where(p => p.CategoryId == 7)
                .Select(c => c.Capacity)
                .Distinct()
                .ToList();

            var ramsModel = new AllRAMsQueryModel
            {
                Sorting = query.Sorting,
                Makes = ramsMakes,
                Capacities = ramCapacities,
                MinSpeeds = ramsSpeeds,
                RAMs = rams,
                SearchTerm = query.SearchTerm,
                CurrentPage = query.CurrentPage,
                TotalCount = totalCount,
                Make = query.Make
            };



            return View(ramsModel);
        }

        public IActionResult Details(string id)
        {
            var ram = this.data.Products.Where(p => p.CategoryId == 7).Where(c => c.Id == Int32.Parse(id)).Select(c => new RAMsDetailsViewModel
            {
                ImagePath = c.ImagePath,
                Make = c.Make,
                Model = c.Model,
                Capacity = c.Capacity,
                MinSpeed = c.MinSpeed,
                Timings = c.Timings,
                NumberOfSticks = c.NumberOfSticks,
                Price = c.Price,
                ReleasedYear = c.ReleasedYear
            }).FirstOrDefault();

            if (ram == null)
            {
                return BadRequest();
            }

            return View(ram);
        }
    }
}
