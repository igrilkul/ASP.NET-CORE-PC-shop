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
            if (!checkData())
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
                TDP = 60,
                Price = 175.00,
                ReleasedYear=2020
            });

            this.cpus.Add(new CPU
            {
                ImagePath = "https://p1.akcdn.net/gallery/558582354/full/1012998.intel-core-i5-10400f-6-core-2-9ghz-lga1200.jpg",
                Platform = "Intel",
                Model = "Core i5-10400F",
                BoostFrequencies = "2900 MHz - 	4300 MHz",
                TDP = 65,
                Price = 140.00,
                ReleasedYear=2015
            });

            this.cpus.Add(new CPU
            {
                ImagePath = "https://p1.akcdn.net/full/534241461.intel-core-i7-9700k-octa-core-3-6-ghz-lga1151.jpg",
                Platform = "Intel",
                Model = "Core i7-9700K",
                BoostFrequencies = "3600 MHz - 	4900 MHz",
                TDP = 95,
                Price = 240.00,
                ReleasedYear = 2018
            });

            this.cpus.Add(new CPU
            {
                ImagePath = "https://p1.akcdn.net/full/685947894.intel-core-i9-10900k-10-core-3-7ghz-lga1200.jpg",
                Platform = "Intel",
                Model = "Core i9-10900K",
                BoostFrequencies = "3700 MHz - 	5300 MHz",
                TDP = 125,
                Price = 530.00,
                ReleasedYear = 2020
            });

            this.cpus.Add(new CPU
            {
                ImagePath = "https://p1.akcdn.net/full/633090768.amd-ryzen-threadripper-3970x-32-core-3-7ghz-trx4.jpg",
                Platform = "AMD",
                Model = "Ryzen Threadripper 3970X",
                BoostFrequencies = "3700 MHz - 	4500 MHz",
                TDP = 280,
                Price = 2150.00,
                ReleasedYear = 2020
            });
        }

        

        
    }
}
