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

            this.cpucoolers.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/79907471.cooler-master-hyper-212-evo-120x80x159mm-rr-212e-16pk-r1.jpg",
                Make = "Cooler Master",
                Model = "Hyper 212 EVO",
                Price = 33,
                ReleasedYear = 2017,
                Airflow = 115.12,
                RPM = 1600,
                Noise = 31,
                Dimensions = "159 x 120 x 51",
                CategoryId = 3
            });

            this.cpucoolers.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/497344079.be-quiet-dark-rock-pro-4-bk022.jpg",
                Make = "Be quiet!",
                Model = "DARK ROCK PRO 4",
                Price = 35,
                ReleasedYear = 2020,
                Airflow = 123.12,
                RPM = 1500,
                Noise = 24.4,
                Dimensions = "162.8 x 123.7 x 136",
                CategoryId = 3
            });

            this.cpucoolers.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/552901563.arctic-freezer-34-esports-duo-acfre00060a-61a-62a-63a-74a-75a.jpg",
                Make = "Arctic",
                Model = "Freezer 34",
                Price = 95,
                ReleasedYear = 2020,
                Airflow = 135.12,
                RPM = 2100,
                Noise = 28,
                Dimensions = "124 x 157 x 103",
                CategoryId = 3
            });

            this.cpucoolers.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/677448282.noctua-chromax-nh-d15-fan-nh-d15-ch.jpg",
                Make = "Noctua",
                Model = "Chromax NH-D15",
                Price = 98,
                ReleasedYear = 2020,
                Airflow = 115.12,
                RPM = 1500,
                Noise = 24.6,
                Dimensions = "150 x 165 x 161",
                CategoryId = 3
            });

            this.cpucoolers.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/670988097.deepcool-gammaxx-400-v2.jpg",
                Make = "Deepcool",
                Model = "Gammaxx 400 V2",
                Price = 15,
                ReleasedYear = 2020,
                Airflow = 64.5,
                RPM = 1650,
                Noise = 27.8,
                Dimensions = "129 x 77 x 155",
                CategoryId = 3
            });

            this.cpucoolers.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/704263377.zalman-cnps10x-optima-ii.jpg",
                Make = "Zalman",
                Model = "CNPS10X Optima II",
                Price = 25,
                ReleasedYear = 2020,
                Airflow = 61.52,
                RPM = 1500,
                Noise = 17,
                Dimensions = "120 x 120 x 25",
                CategoryId = 3
            });
        }

    }
}
