using PCShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class PSUSeeder : ISeeder
    {
        public PCShopDbContext data;
        private List<Product> psus;

        public PSUSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.psus = new List<Product>();
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
            return this.data.Products.Where(p => p.CategoryId == 6).Any();
        }

        public void seedData()
        {
            this.data.Products.AddRange(this.psus);
            this.data.SaveChanges();
        }

        public void prepareData()
        {
            this.psus.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/493165149.corsair-rmx-series-rm850x-2018-850w-gold-cp-9020180.jpg",
                Make = "Corsair",
                Model = "RM850x",
                Power = 850,
                Efficiency = "80+ Gold",
                Price = 150,
                ReleasedYear=2020,
                CategoryId = 6
            });

            this.psus.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/493165149.corsair-rmx-series-rm850x-2018-850w-gold-cp-9020180.jpg",
                Make = "Corsair",
                Model = "RM750x",
                Power = 750,
                Efficiency = "80+ Gold",
                Price = 130,
                ReleasedYear = 2020,
                CategoryId = 6
            });

            this.psus.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/493165149.corsair-rmx-series-rm850x-2018-850w-gold-cp-9020180.jpg",
                Make = "Corsair",
                Model = "RM650x",
                Power = 650,
                Efficiency = "80+ Gold",
                Price = 110,
                ReleasedYear = 2020,
                CategoryId = 6
            });
        }
    }
}
