using PCShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class RAMSeeder : ISeeder
    {
        public PCShopDbContext data;
        private List<RAM> rams;

        public RAMSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.rams = new List<RAM>();
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
            if (this.data.RAMs.Any())
            {
                return true;
            }
            else return false;
        }

        public void seedData()
        {
            this.data.RAMs.AddRange(this.rams);
            this.data.SaveChanges();
        }

        public void prepareData()
        {
            this.rams.Add(new RAM
            {
                ImagePath = "https://p1.akcdn.net/full/545789382.corsair-vengeance-rgb-pro-16gb-2x8gb-ddr4-3200mhz-cmw16gx4m2c3200c16.jpg",
                Make = "Corsair",
                Model = "VENGEANCE RGB Pro",
                Size = 16,
                NumberOfSticks = 2,
                Timings = "16-18-18-36",
                Price = 110,
                Speed = 3200,
                ReleasedYear=2018
            });
            
            this.rams.Add(new RAM
            {
                ImagePath = "https://p1.akcdn.net/full/615010312.g-skill-trident-z-neo-16gb-2x8gb-ddr4-3600mhz-f4-3600c16d-16gtznc.jpg",
                Make = "G.SKILL",
                Model = "Trident Z Neo",
                Size = 16,
                NumberOfSticks = 2,
                Timings = "16-19-19-39",
                Price = 140,
                Speed = 3600,
                ReleasedYear = 2017
            });
        }
    }
}
