using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using PCShop.Models;
using PCShop.Models.Motherboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Controllers
{
    public class MotherboardsController : Controller
    {
        private readonly PCShopDbContext data;

        public MotherboardsController(
            PCShopDbContext data)
        {
            this.data = data;
        }

        public IActionResult All([FromQuery] AllMotherboardsQueryModel query)
        {
            var motherboardsQuery = this.data.Products.Where(p => p.CategoryId == 5).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Platform))
            {
                motherboardsQuery = motherboardsQuery.Where(c => c.Platform == query.Platform);
            }

            if (!string.IsNullOrWhiteSpace(query.Make))
            {
                motherboardsQuery = motherboardsQuery.Where(c => c.Make == query.Make);
            }

            if (!string.IsNullOrWhiteSpace(query.Model))
            {
                motherboardsQuery = motherboardsQuery.Where(c => c.Model == query.Model);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                motherboardsQuery = motherboardsQuery.Where(c =>
                c.Platform.ToLower().Contains(query.SearchTerm.ToLower())
                || c.Make.ToLower().Contains(query.SearchTerm.ToLower())
                || c.Model.ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Make + " " + c.Model).ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Platform + " " + c.Make + " " + c.Model).ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Platform + " " + c.Model).ToLower().Contains(query.SearchTerm.ToLower()));
            }

            motherboardsQuery = query.Sorting switch
            {
                MotherboardSorting.ReleasedYear => motherboardsQuery.OrderByDescending(c => c.ReleasedYear),
                MotherboardSorting.Price => motherboardsQuery.OrderByDescending(c => c.Price),
                MotherboardSorting.Size => motherboardsQuery.OrderByDescending(c => c.Size),
                _ => motherboardsQuery.OrderByDescending(c => c.Id)
            };

            var motherboards = motherboardsQuery
                .Skip((query.CurrentPage - 1) * AllMotherboardsQueryModel.ItemsPerPage)
                .Take(AllMotherboardsQueryModel.ItemsPerPage)
                 .Select(c => new ProductListViewModel
                 {
                     Id = c.Id,
                     CategoryId = c.CategoryId,
                     Size = c.Size,
                     ImagePath = c.ImagePath,
                     Platform = c.Platform,
                     Make = c.Make,
                     Model = c.Model,
                     Price = c.Price,
                 })
                 .ToList();

            var totalCount = motherboardsQuery.Count();

            var motherboardsPlatforms = this.data
                .Products.Where(p => p.CategoryId == 5)
                .Select(c => c.Platform)
                .Distinct()
                .ToList();

            var motherboardsMakes = this.data
                .Products.Where(p => p.CategoryId == 5)
                .Select(c => c.Make)
                .Distinct()
                .ToList();

            var motherboardsModels = this.data
                .Products.Where(p => p.CategoryId == 5)
                .Select(c => c.Model)
                .Distinct()
                .ToList();

            var motherboardsModel = new AllMotherboardsQueryModel
            {
                Sorting = query.Sorting,
                Platforms = motherboardsPlatforms,
                Makes = motherboardsMakes,
                Models = motherboardsModels,
                Motherboards = motherboards,
                SearchTerm = query.SearchTerm,
                CurrentPage = query.CurrentPage,
                TotalCount = totalCount,
                Platform = query.Platform,
                Make = query.Make,
                Model = query.Model
            };



            return View(motherboardsModel);
        }

        public IActionResult Details(string id)
        {
            var motherboard = this.data.Products.Where(p => p.CategoryId == 5).Where(c => c.Id == Int32.Parse(id)).Select(c => new MotherboardsDetailsViewModel
            {
                ImagePath = c.ImagePath,
                Platform = c.Platform,
                Make = c.Make,
                Model = c.Model,
                Size = c.Size,
                Price = c.Price,
                ReleasedYear = c.ReleasedYear
            }).FirstOrDefault();

            if (motherboard == null)
            {
                return BadRequest();
            }

            return View(motherboard);
        }
    }
}
