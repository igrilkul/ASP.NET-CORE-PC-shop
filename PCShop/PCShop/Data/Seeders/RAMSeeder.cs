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
                ReleasedYear=2018
            });
        }
    }
}
