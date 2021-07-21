using PCShop.Data.Models;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class MotherboardSeeder : ISeeder
    {
        public PCShopDbContext data;
        private List<Motherboard> mobos;

        public MotherboardSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.mobos = new List<Motherboard>();
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
            if (this.data.Motherboards.Any())
            {
                return true;
            }
            else return false;
        }

        public void seedData()
        {
            this.data.Motherboards.AddRange(this.mobos);
            this.data.SaveChanges();
        }

        public void prepareData()
        {
            this.mobos.Add(new Motherboard
            {
                ImagePath = "https://p1.akcdn.net/full/757175553.msi-b450-tomahawk-max-ii.jpg",
                Make = "MSI",
                Platform = "AMD",
                Model = "B450 Tomahawk Max",
                Price = 110,
                Size = "ATX",
                ReleasedYear=2019
            });

            this.mobos.Add(new Motherboard
            {
                ImagePath = "https://p1.akcdn.net/full/706209471.msi-b460m-a-pro.jpg",
                Make = "MSI",
                Platform = "Intel",
                Model = "B460M-A PRO",
                Price = 65,
                Size = "mATX",
                ReleasedYear = 2018
            });
        }

    }
}
