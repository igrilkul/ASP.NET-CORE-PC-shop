using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Areas.Admin.Models;
using PCShop.Data;
using PCShop.Data.Models;
using PCShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PCShop.Areas.Admin.Controllers
{
        [Area("Admin")]
        [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private PCShopDbContext data;

        public AdminController(
            PCShopDbContext data)
        {
            this.data = data;
        }

        public IActionResult All()
        {
            return View();
        }

        public IActionResult Add()
        {
            var itemForm = new ItemFormModel { };
            return View(itemForm);
        }

        [HttpPost]
        public IActionResult Add(ItemFormModel itemFormModel)
        {
            if(itemFormModel == null)
            {
                return RedirectToAction("Add");
            }

            if(itemFormModel.Price.Equals(null) || itemFormModel.Model == null)
            {
                RedirectToAction("Add", itemFormModel);
            }

            var product = new Product
            {
                CategoryId = itemFormModel.CategoryId,
                ImagePath = itemFormModel.ImagePath,
                Platform = itemFormModel.Platform,
                Make = itemFormModel.Make,
                Model = itemFormModel.Model,
                Price = itemFormModel.Price,
                ReleasedYear = itemFormModel.ReleasedYear,
                Size = itemFormModel.Size,
                MinSpeed = itemFormModel.MinSpeed,
                MaxSpeed = itemFormModel.MaxSpeed,
                TDP = itemFormModel.TDP,
                NumberOfFans = itemFormModel.NumberOfFans,
                Airflow = itemFormModel.Airflow,
                RPM = itemFormModel.RPM,
                Noise = itemFormModel.Noise,
                Dimensions = itemFormModel.Dimensions,
                Power = itemFormModel.Power,
                Efficiency = itemFormModel.Efficiency,
                NumberOfSticks = itemFormModel.NumberOfSticks,
                Timings = itemFormModel.Timings,
                Capacity = itemFormModel.Capacity
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();

            return RedirectToAction("Admin/All");
        }

        public IActionResult Edit()
        {
            if (!this.User.IsInRole("Administrator"))
            {
                return BadRequest();
            }
            else
            {
                var categories = this.data.Categories.Select(c=>new CategoriesListModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();

                return View(categories);
            }
        }

        public IActionResult EditList(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || !int.TryParse(id, out _))
            {
                return BadRequest();
            }

            int categoryId = Int32.Parse(id);


            var productList = this.data.Products
                        .Where(p => p.CategoryId == categoryId)
                        .Select(p => new ProductListViewModel
                        {
                            Id = p.Id,
                            ImagePath = p.ImagePath,
                            Platform = p.Platform,
                            Make = p.Make,
                            Model = p.Model,
                            Price = p.Price,
                            Size = p.Size,
                            MinSpeed = p.MinSpeed,
                            Capacity = p.Capacity,
                            ReleasedYear = p.ReleasedYear,
                            Power = p.Power,
                            Efficiency = p.Efficiency
                        }).ToList();

            return View(productList);
        }

        public IActionResult EditItem(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || !int.TryParse(id, out _))
            {
                return BadRequest();
            }

            int productId = Int32.Parse(id);

            var product = this.data.Products.Where(p => p.Id == productId).FirstOrDefault();

            if(product == null)
            {
                return BadRequest();
            }

            var productModel = new ProductDetailsViewModel
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                ImagePath = product.ImagePath,
                Platform = product.Platform,
                Make = product.Make,
                Model = product.Model,
                Price = product.Price,
                ReleasedYear = product.ReleasedYear,
                Size = product.Size,
                MinSpeed = product.MinSpeed,
                MaxSpeed = product.MaxSpeed,
                TDP = product.TDP,
                NumberOfFans = product.NumberOfFans,
                Airflow = product.Airflow,
                RPM = product.RPM,
                Noise = product.Noise,
                Dimensions = product.Dimensions,
                Power = product.Power,
                Efficiency = product.Efficiency,
                NumberOfSticks = product.NumberOfSticks,
                Timings = product.Timings,
                Capacity = product.Capacity
            };

            return View(productModel);
        }

        [HttpPost]
        public IActionResult EditItem(ProductDetailsViewModel product)
        {
            if(product == null)
            {
                return BadRequest();
            }

            if (product.Price.Equals(null) || product.Price == 0)
            {
                return RedirectToAction("EditItem", product);
            }

            if(product.Id.Equals(null))
            {
                return BadRequest();
            }

            var item = this.data.Products.Where(x => x.Id == product.Id).FirstOrDefault();
            if(item == null)
            {
                return BadRequest();
            }

            item.CategoryId = product.CategoryId;
            item.ImagePath = product.ImagePath;
            item.Platform = product.Platform;
            item.Make = product.Make;
            item.Model = product.Model;
            item.Price = product.Price;
            item.ReleasedYear = product.ReleasedYear;
            item.Size = product.Size;
            item.MinSpeed = product.MinSpeed;
            item.MaxSpeed = product.MaxSpeed;
            item.TDP = product.TDP;
            item.NumberOfFans = product.NumberOfFans;
            item.Airflow = product.Airflow;
            item.RPM = product.RPM;
            item.Noise = product.Noise;
            item.Dimensions = product.Dimensions;
            item.Power = product.Power;
            item.Efficiency = product.Efficiency;
            item.NumberOfSticks = product.NumberOfSticks;
            item.Timings = product.Timings;
            item.Capacity = product.Capacity;

            this.data.Products.Update(item);
            this.data.SaveChanges();

            return RedirectToAction("Edit");
        }

        
        public IActionResult DeleteItem(string id)
        {
            var product = this.data.Products.Where(x => x.Id == Int32.Parse(id)).FirstOrDefault();
            if (product == null)
            {
                return BadRequest();
            }

            this.data.Products.Remove(product);
            this.data.SaveChanges();

            return RedirectToAction("Edit");
        }
    }
}

