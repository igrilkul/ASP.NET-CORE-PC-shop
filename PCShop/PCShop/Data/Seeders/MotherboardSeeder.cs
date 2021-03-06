using PCShop.Data.Models;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class MotherboardSeeder : ISeeder
    {
        public PCShopDbContext data;
        private List<Product> mobos;

        public MotherboardSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.mobos = new List<Product>();
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
            return this.data.Products.Where(p => p.CategoryId == 5).Any();
        }

        public void seedData()
        {
            this.data.Products.AddRange(this.mobos);
            this.data.SaveChanges();
        }

        public void prepareData()
        {
            this.mobos.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/757175553.msi-b450-tomahawk-max-ii.jpg",
                Make = "MSI",
                Platform = "AMD",
                Model = "B450 Tomahawk Max",
                Price = 110,
                Size = "ATX",
                ReleasedYear=2019,
                CategoryId = 5
            });

            this.mobos.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/706209471.msi-b460m-a-pro.jpg",
                Make = "MSI",
                Platform = "Intel",
                Model = "B460M-A PRO",
                Price = 65,
                Size = "mATX",
                ReleasedYear = 2018,
                CategoryId = 5
            });
        }

    }
}
