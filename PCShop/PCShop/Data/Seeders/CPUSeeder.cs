using PCShop.Data.Models;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class CPUSeeder : ISeeder
    {
        public PCShopDbContext data;
        private List<Product> cpus;

        public CPUSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.cpus = new List<Product>();
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
            return this.data.Products.Where(p => p.CategoryId == 2).Any();
        }

        public void seedData()
        {
            this.data.Products.AddRange(this.cpus);
            this.data.SaveChanges();
        }

        public void prepareData()
        {
            this.cpus.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/592283181.amd-ryzen-5-3600-hexa-core-3-6ghz-am4.jpg",
                Platform = "AMD",
                Model = "Ryzen 5 3600",
                MinSpeed = 3600,
                MaxSpeed = 4200,
                TDP = 60,
                Price = 175.00,
                ReleasedYear = 2020,
                CategoryId = 2
            });

            this.cpus.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/gallery/558582354/full/1012998.intel-core-i5-10400f-6-core-2-9ghz-lga1200.jpg",
                Platform = "Intel",
                Model = "Core i5-10400F",
                MinSpeed = 2900,
                MaxSpeed = 4300,
                TDP = 65,
                Price = 140.00,
                ReleasedYear = 2015,
                CategoryId = 2
            });

            this.cpus.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/534241461.intel-core-i7-9700k-octa-core-3-6-ghz-lga1151.jpg",
                Platform = "Intel",
                Model = "Core i7-9700K",
                MinSpeed = 3600,
                MaxSpeed = 4900,
                TDP = 95,
                Price = 240.00,
                ReleasedYear = 2018,
                CategoryId = 2
            });

            this.cpus.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/685947894.intel-core-i9-10900k-10-core-3-7ghz-lga1200.jpg",
                Platform = "Intel",
                Model = "Core i9-10900K",
                MinSpeed = 3700,
                MaxSpeed = 5300,
                TDP = 125,
                Price = 530.00,
                ReleasedYear = 2020,
                CategoryId = 2
            });

            this.cpus.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/633090768.amd-ryzen-threadripper-3970x-32-core-3-7ghz-trx4.jpg",
                Platform = "AMD",
                Model = "Ryzen Threadripper 3970X",
                MinSpeed = 3700,
                MaxSpeed = 4500,
                TDP = 280,
                Price = 2150.00,
                ReleasedYear = 2020,
                CategoryId = 2
            });
        }

        

        
    }
}
