using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using PCShop.Models.GPUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Controllers
{
    public class GPUsController : Controller
    {
        private readonly PCShopDbContext data;

        public GPUsController(
            PCShopDbContext data)
        {
            this.data = data;
        }

        public IActionResult All([FromQuery] AllGPUsQueryModel query)
        {
            var gpusQuery = this.data.GPUs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Platform))
            {
                gpusQuery = gpusQuery.Where(c => c.Platform == query.Platform);
            }

            if (!string.IsNullOrWhiteSpace(query.Make))
            {
                gpusQuery = gpusQuery.Where(c => c.Make == query.Make);
            }

            if (!string.IsNullOrWhiteSpace(query.Model))
            {
                gpusQuery = gpusQuery.Where(c => c.Model == query.Model);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                gpusQuery = gpusQuery.Where(c =>
                c.Platform.ToLower().Contains(query.SearchTerm.ToLower())
                || c.Make.ToLower().Contains(query.SearchTerm.ToLower())
                || c.Model.ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Make + " " + c.Model).ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Platform + " " + c.Make + " " + c.Model).ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Platform + " " + c.Model).ToLower().Contains(query.SearchTerm.ToLower()));
            }

            gpusQuery = query.Sorting switch
            {
                GPUSorting.ReleasedYear => gpusQuery.OrderByDescending(c => c.ReleasedYear),
                GPUSorting.Price => gpusQuery.OrderByDescending(c => c.Price),
                GPUSorting.BoostClock => gpusQuery.OrderByDescending(c => c.BoostClock),
                GPUSorting.NumberOfFans => gpusQuery.OrderByDescending(c => c.NumberOfFans),                
                _ => gpusQuery.OrderByDescending(c => c.Id)
            };

            var gpus = gpusQuery
                .Skip((query.CurrentPage - 1) * AllGPUsQueryModel.ItemsPerPage)
                .Take(AllGPUsQueryModel.ItemsPerPage)
                 .Select(c => new GPUsListViewModel
                 {
                     Id = c.Id,
                     ImagePath = c.ImagePath,
                     Platform = c.Platform,
                     Make = c.Make,
                     Model = c.Model,
                     Price = c.Price,
                 })
                 .ToList();

            var totalCount = gpusQuery.Count();

            var gpuPlatforms = this.data
                .GPUs
                .Select(c => c.Platform)
                .Distinct()
                .ToList();

            var gpuMakes = this.data
                .GPUs
                .Select(c => c.Make)
                .Distinct()
                .ToList();

            var gpuModels = this.data
                .GPUs
                .Select(c => c.Model)
                .Distinct()
                .ToList();

            var gpusModel = new AllGPUsQueryModel
            {
                Sorting = query.Sorting,
                Platforms = gpuPlatforms,
                Makes = gpuMakes,
                Models = gpuModels,
                GPUs = gpus,
                SearchTerm = query.SearchTerm,
                CurrentPage = query.CurrentPage,
                TotalCount = totalCount,
                Platform = query.Platform,
                Make = query.Make,
                Model = query.Model
            };



            return View(gpusModel);
        }

        public IActionResult Details(string id)
        {
            var gpu = this.data.GPUs.Where(c => c.Id == Int32.Parse(id)).Select(c => new GPUsDetailsViewModel
            {
                ImagePath = c.ImagePath,
                Platform = c.Platform,
                Make = c.Make,
                Model = c.Model,
                Price = c.Price,
                ReleasedYear = c.ReleasedYear,
                NumberOfFans = c.NumberOfFans,
                BoostClock = c.BoostClock,
            }).FirstOrDefault();

            if (gpu == null)
            {
                return BadRequest();
            }

            return View(gpu);
        }
    }
}
