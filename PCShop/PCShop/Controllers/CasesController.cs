using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using PCShop.Models;
using PCShop.Models.Cases;
using System;
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

        public IActionResult All([FromQuery] AllCasesQueryModel query)
        {
            var casesQuery = this.data.Products.Where(p=>p.CategoryId==1).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Make))
            {
                casesQuery = casesQuery.Where(c => c.Make == query.Make);
            }

            if (!string.IsNullOrWhiteSpace(query.Size))
            {
                casesQuery = casesQuery.Where(c => c.Size == query.Size);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                casesQuery = casesQuery.Where(c =>
                c.Make.ToLower().Contains(query.SearchTerm.ToLower())
                || c.Model.ToLower().Contains(query.SearchTerm.ToLower())
                || (c.Make + " " + c.Model).ToLower().Contains(query.SearchTerm.ToLower()));
            }

            casesQuery = query.Sorting switch
            {
                CaseSorting.Price => casesQuery.OrderByDescending(c => c.Price),
                CaseSorting.ReleasedYear => casesQuery.OrderByDescending(c => c.ReleasedYear),
                CaseSorting.Size => casesQuery.OrderByDescending(c => c.Size),
                _ => casesQuery.OrderByDescending(c => c.Id)
            };

            var cases = casesQuery
                .Skip((query.CurrentPage - 1) * AllCasesQueryModel.CasesPerPage)
                .Take(AllCasesQueryModel.CasesPerPage)
                 .Select(c => new ProductListViewModel
                 {
                     Id = c.Id,
                     CategoryId = c.CategoryId,
                     ImagePath = c.ImagePath,
                     Make = c.Make,
                     Model = c.Model,
                     Size = c.Size,
                     Price = c.Price,
                     ReleasedYear = c.ReleasedYear
                 })
                 .ToList();

            var casesCount = casesQuery.Count();

            var casesMakes = this.data
                .Products.Where(p=>p.CategoryId==1)
                .Select(c => c.Make)
                .Distinct()
                .ToList();

            var casesSizes = this.data
                .Products.Where(p => p.CategoryId == 1)
                .Select(c => c.Size)
                .Distinct()
                .ToList();

            var casesModel = new AllCasesQueryModel
            {
                Sorting = query.Sorting,
                Makes = casesMakes,
                Sizes=casesSizes,
                Cases = cases,
                SearchTerm = query.SearchTerm,
                CurrentPage = query.CurrentPage,
                TotalCases = casesCount,
                Make = query.Make
            };



            return View(casesModel);
        }

        public IActionResult Details(string id)
        {
            int idInt = Int32.Parse(id);
            var caso = this.data.Products.Where(p=>p.CategoryId==1).Where(c => c.Id == Int32.Parse(id)).Select(c => new ProductDetailsViewModel
            {
                ImagePath = c.ImagePath,
                Make = c.Make,
                Model = c.Model,
                Size = c.Size,
                Price = c.Price,
                ReleasedYear = (int)c.ReleasedYear
            }).FirstOrDefault();

            if (caso == null)
            {
                return BadRequest();
            }

            return View(caso);
        }

       

    }
}
