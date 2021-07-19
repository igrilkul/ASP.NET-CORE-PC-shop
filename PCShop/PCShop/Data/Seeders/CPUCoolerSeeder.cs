using PCShop.Data.Models;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class CPUCoolerSeeder : ISeeder
    {
        public PCShopDbContext data;
        private List<CPUCooler> cpucoolers;

        public CPUCoolerSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.cpucoolers = new List<CPUCooler>();
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
            if (this.data.CPUCoolers.Any())
            {
                return true;
            }
            else return false;
        }

        public void seedData()
        {
            this.data.CPUCoolers.AddRange(this.cpucoolers);
            this.data.SaveChanges();
        }

        public void prepareData()
        {
            this.cpucoolers.Add(new CPUCooler
            {
                ImagePath = "https://p1.akcdn.net/full/678025767.noctua-noctua-nh-u12s-fan-nh-u12s-ch.jpg",
                Make = "Noctua",
                Model = "NH-U12S Chromax",
                Price = 70,
                ReleasedYear=2015
            });

            this.cpucoolers.Add(new CPUCooler
            {
                ImagePath = "https://p1.akcdn.net/full/552901563.arctic-freezer-34-esports-duo-acfre00060a-61a-62a-63a-74a-75a.jpg",
                Make = "Arctic",
                Model = "Freezer 34",
                Price = 35,
                ReleasedYear=2020
            });
        }

    }
}
