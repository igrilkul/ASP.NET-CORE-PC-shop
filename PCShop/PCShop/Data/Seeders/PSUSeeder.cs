using PCShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class PSUSeeder : ISeeder
    {
        public PCShopDbContext data;
        private List<PSU> psus;

        public PSUSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.psus = new List<PSU>();
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
            if (this.data.PSUs.Any())
            {
                return true;
            }
            else return false;
        }

        public void seedData()
        {
            this.data.PSUs.AddRange(this.psus);
            this.data.SaveChanges();
        }

        public void prepareData()
        {
            this.psus.Add(new PSU
            {
                ImagePath = "https://p1.akcdn.net/full/493165149.corsair-rmx-series-rm850x-2018-850w-gold-cp-9020180.jpg",
                Make = "Corsair",
                Model = "RM850x",
                Power = 850,
                Efficiency = "80+ Gold",
                Price = 150,
                ReleasedYear=2020
            });

        }
    }
}
