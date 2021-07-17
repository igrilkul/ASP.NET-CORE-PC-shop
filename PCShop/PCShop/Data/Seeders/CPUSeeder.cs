using PCShop.Data.Models;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class CPUSeeder : ISeeder
    {
        public PCShopDbContext data;
        private List<CPU> cpus;

        public CPUSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.cpus = new List<CPU>();
        }

        public void start()
        {
            if (checkData())
            {
                prepareData();
                seedData();
            }
        }

        public bool checkData()
        {
            if (this.data.CPUs.Any())
            {
                return true;
            }
            else return false;
        }

        public void seedData()
        {
            this.data.CPUs.AddRange(this.cpus);
            this.data.SaveChanges();
        }

        public void prepareData()
        {
            this.cpus.Add(new CPU
            {
                ImagePath = "https://p1.akcdn.net/full/592283181.amd-ryzen-5-3600-hexa-core-3-6ghz-am4.jpg",
                Platform = "AMD",
                Model = "Ryzen 5 3600",
                BoostFrequencies = "3600 MHz - 	4200 MHz",
                TDP = "65W",
                Price = 175.00
            });

            this.cpus.Add(new CPU
            {
                ImagePath = "https://p1.akcdn.net/gallery/558582354/full/1012998.intel-core-i5-10400f-6-core-2-9ghz-lga1200.jpg",
                Platform = "Intel",
                Model = "Core i5-10400F",
                BoostFrequencies = "2900 MHz - 	4300 MHz",
                TDP = "65W",
                Price = 140.00
            });
        }

        

        
    }
}
