using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using PCShop.Models.PSUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Controllers
{
    public class PSUsController:Controller
    {
        private readonly PCShopDbContext data;

        public PSUsController(
            PCShopDbContext data)
        {
            this.data = data;
        }

        public IActionResult All([FromQuery] AllPSUsQueryModel query)
        {
            var PSUsQuery = this.data.PSUs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Make))
            {
                PSUsQuery = PSUsQuery.Where(c => c.Make == query.Make);
            }

            if (!string.IsNullOrWhiteSpace(query.Efficiency))
            {
                PSUsQuery = PSUsQuery.Where(c => c.Efficiency == query.Efficiency);
            }

            if (!string.IsNullOrWhiteSpace(query.Power.ToString()))
            {
                PSUsQuery = PSUsQuery.Where(c => c.Power == query.Power);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                PSUsQuery = PSUsQuery.Where(c =>
                c.Make.ToLower().Contains(query.SearchTerm.ToLower())
                || c.Model.ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Make + " " + c.Model).ToLower().Contains(query.SearchTerm.ToLower()));
            }

            PSUsQuery = query.Sorting switch
            {
                PSUSorting.ReleasedYear => PSUsQuery.OrderByDescending(c => c.ReleasedYear),
                PSUSorting.Price => PSUsQuery.OrderByDescending(c => c.Price),
                PSUSorting.Power => PSUsQuery.OrderByDescending(c => c.Power),
                PSUSorting.Efficiency => PSUsQuery.OrderByDescending(c => c.Efficiency),
                _ => PSUsQuery.OrderByDescending(c => c.Id)
            };

            var psus = PSUsQuery
                .Skip((query.CurrentPage - 1) * AllPSUsQueryModel.ItemsPerPage)
                .Take(AllPSUsQueryModel.ItemsPerPage)
                 .Select(c => new PSUsListViewModel
                 {
                     Id = c.Id,
                     ImagePath = c.ImagePath,
                     Make = c.Make,
                     Model = c.Model,
                     Price = c.Price,
                     Power = c.Power,
                     Efficiency = c.Efficiency
                 })
                 .ToList();

            var totalCount = PSUsQuery.Count();

            var psusPowers = this.data
                .PSUs
                .Select(c => c.Power)
                .Distinct()
                .ToList();

            var psusMakes = this.data
                .PSUs
                .Select(c => c.Make)
                .Distinct()
                .ToList();

            var psusEfficiencies = this.data
                .PSUs
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
            var psu = this.data.PSUs.Where(c => c.Id == Int32.Parse(id)).Select(c => new PSUsDetailsViewModel
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
                return BadRequest();
            }

            return View(psu);
        }
    }
}
