using PCShop.Data.Models;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class CPUCoolerSeeder : ISeeder
    {
        public PCShopDbContext data;
        private List<Product> cpucoolers;

        public CPUCoolerSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.cpucoolers = new List<Product>();
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
            return this.data.Products.Where(p => p.CategoryId == 3).Any();
        }

        public void seedData()
        {
            this.data.Products.AddRange(this.cpucoolers);
            this.data.SaveChanges();
        }

        public void prepareData()
        {
            this.cpucoolers.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/678025767.noctua-noctua-nh-u12s-fan-nh-u12s-ch.jpg",
                Make = "Noctua",
                Model = "NH-U12S Chromax",
                Price = 70,
                ReleasedYear=2015,
                Airflow=54.90,
                RPM = 1500,
                Noise=22.4,
                Dimensions = "158 x 125 x 71",
                CategoryId = 3
            });

            this.cpucoolers.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/552901563.arctic-freezer-34-esports-duo-acfre00060a-61a-62a-63a-74a-75a.jpg",
                Make = "Arctic",
                Model = "Freezer 34",
                Price = 35,
                ReleasedYear=2020,
                Airflow = 135.12,
                RPM = 2100,
                Noise = 28,
                Dimensions = "124 x 157 x 103",
                CategoryId = 3
            });
        }

    }
}
