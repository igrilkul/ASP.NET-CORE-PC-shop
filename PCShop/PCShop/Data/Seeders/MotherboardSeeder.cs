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
                Platfom = "AMD",
                Model = "B450 Tomahawk Max",
                Price = 110,
                ReleasedYear=2019
            });
        }

    }
}
