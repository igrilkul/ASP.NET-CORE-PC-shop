using PCShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Data.Seeders
{
    public class CategorySeeder : ISeeder
    {
        public PCShopDbContext data;
        private List<Category> categories;

        public CategorySeeder(PCShopDbContext data)
        {
            this.data = data;
            this.categories = new List<Category>();
        }

        public void start()
        {
            if (!checkData())
            {
                prepareData();
                seedData();
            }
        }

        public bool checkData()
        {
            return this.data.Categories.Any();
        }

        public void seedData()
        {
            this.data.Categories.AddRange(this.categories);
            this.data.SaveChanges();
        }

        public void prepareData()
        {
            this.categories.Add(new Category
            {
                Name = "Case"
            });

            this.categories.Add(new Category
            {
                Name = "CPU"
            });

            this.categories.Add(new Category
            {
                Name = "CPU Cooler"
            });

            this.categories.Add(new Category
            {
                Name = "GPU"
            });

            this.categories.Add(new Category
            {
                Name = "Motherboard"
            });

            this.categories.Add(new Category
            {
                Name = "PSU"
            });

            this.categories.Add(new Category
            {
                Name = "RAM"
            });

        }
    }
}
