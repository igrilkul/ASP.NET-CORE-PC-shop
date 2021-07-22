using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
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
            var ramsQuery = this.data.RAMs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Make))
            {
                ramsQuery = ramsQuery.Where(c => c.Make == query.Make);
            }

            if (!(query.Size == 0))
            {
                ramsQuery = ramsQuery.Where(c => c.Size == query.Size);
            }

            if (!(query.Speed == 0))
            {
                ramsQuery = ramsQuery.Where(c => c.Speed == query.Speed);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                ramsQuery = ramsQuery.Where(c =>
                c.Make.ToLower().Contains(query.SearchTerm.ToLower())
                || c.Model.ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Make + " " + c.Model).ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Make + " " + c.Model + " " + c.Size).ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Make + " " + c.Size).ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Model + " " + c.Size).ToLower().Contains(query.SearchTerm.ToLower()));
            }

            ramsQuery = query.Sorting switch
            {
                RAMSorting.ReleasedYear => ramsQuery.OrderByDescending(c => c.ReleasedYear),
                RAMSorting.Price => ramsQuery.OrderByDescending(c => c.Price),
                RAMSorting.Size => ramsQuery.OrderByDescending(c => c.Size),
                RAMSorting.Speed => ramsQuery.OrderByDescending(c => c.Speed),
                _ => ramsQuery.OrderByDescending(c => c.Id)
            };

            var rams = ramsQuery
                .Skip((query.CurrentPage - 1) * AllRAMsQueryModel.ItemsPerPage)
                .Take(AllRAMsQueryModel.ItemsPerPage)
                 .Select(c => new RAMsListViewModel
                 {
                     Id = c.Id,
                     ImagePath = c.ImagePath,
                     Make = c.Make,
                     Model = c.Model,
                     Price = c.Price,
                     Size = c.Size
                 })
                 .ToList();

            var totalCount = ramsQuery.Count();

            var ramsSpeeds = this.data
                .RAMs
                .Select(c => c.Speed)
                .Distinct()
                .ToList();

            var ramsMakes = this.data
                .RAMs
                .Select(c => c.Make)
                .Distinct()
                .ToList();

            var ramsSizes = this.data
                .RAMs
                .Select(c => c.Size)
                .Distinct()
                .ToList();

            var ramsModel = new AllRAMsQueryModel
            {
                Sorting = query.Sorting,
                Makes = ramsMakes,
                Sizes = ramsSizes,
                Speeds = ramsSpeeds,
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
            var ram = this.data.RAMs.Where(c => c.Id == Int32.Parse(id)).Select(c => new RAMsDetailsViewModel
            {
                ImagePath = c.ImagePath,
                Make = c.Make,
                Model = c.Model,
                Size = c.Size,
                Speed = c.Speed,
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
