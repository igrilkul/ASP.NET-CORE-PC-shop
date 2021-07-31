using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using PCShop.Models;
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

        public IActionResult All([FromQuery] AllCPUCoolersQueryModel query)
        {
            var cpuCoolersQuery = this.data.Products.Where(p=>p.CategoryId==3).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Make))
            {
                cpuCoolersQuery = cpuCoolersQuery.Where(c => c.Make == query.Make);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                cpuCoolersQuery = cpuCoolersQuery.Where(c =>
                c.Make.ToLower().Contains(query.SearchTerm.ToLower())
                || c.Model.ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Make + " " + c.Model).ToLower().Contains(query.SearchTerm.ToLower()));
            }

            cpuCoolersQuery = query.Sorting switch
            {
                CPUCoolerSorting.Price => cpuCoolersQuery.OrderByDescending(c => c.Price),
                CPUCoolerSorting.ReleasedYear => cpuCoolersQuery.OrderByDescending(c => c.ReleasedYear),
                CPUCoolerSorting.Airflow => cpuCoolersQuery.OrderByDescending(c => c.Airflow),
                CPUCoolerSorting.RPM => cpuCoolersQuery.OrderByDescending(c => c.RPM),
                CPUCoolerSorting.Noise => cpuCoolersQuery.OrderByDescending(c => c.Noise),
                _ => cpuCoolersQuery.OrderByDescending(c => c.Id)
            };

            var cpuCoolers = cpuCoolersQuery
                .Skip((query.CurrentPage - 1) * AllCPUCoolersQueryModel.ItemsPerPage)
                .Take(AllCPUCoolersQueryModel.ItemsPerPage)
                 .Select(c => new ProductListViewModel
                 {
                     Id = c.Id,
                     CategoryId = c.CategoryId,
                     ImagePath = c.ImagePath,
                     Make = c.Make,
                     Model = c.Model,
                     Price = c.Price,
                     ReleasedYear = c.ReleasedYear
                 })
                 .ToList();

            var cpuCoolersCount = cpuCoolersQuery.Count();

            var coolerMakes = this.data
                .Products.Where(p => p.CategoryId == 3)
                .Select(c => c.Make)
                .Distinct()
                .ToList();

            var cpuCoolersModel = new AllCPUCoolersQueryModel
            {
                Sorting = query.Sorting,
                Makes = coolerMakes,
                CPUCoolers = cpuCoolers,
                SearchTerm = query.SearchTerm,
                CurrentPage = query.CurrentPage,
                TotalCPUCoolers = cpuCoolersCount,
                Make = query.Make
            };



            return View(cpuCoolersModel);
        }

        public IActionResult Details(string id)
        {
            var cpuCooler = this.data.Products.Where(p=>p.CategoryId==3).Where(c => c.Id == Int32.Parse(id)).Select(c => new ProductDetailsViewModel
            {
                ImagePath = c.ImagePath,
                Make = c.Make,
                Model = c.Model,
                Price = c.Price,
                ReleasedYear = c.ReleasedYear,
                Airflow = c.Airflow,
                RPM = c.RPM,
                Noise = c.Noise,
                Dimensions = c.Dimensions
            }).FirstOrDefault();

            if (cpuCooler == null)
            {
                return BadRequest();
            }

            return View(cpuCooler);
        }
    }
}
