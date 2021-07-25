using PCShop.Data.Models;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class GPUSeeder : ISeeder
    {
        public PCShopDbContext data;
        private List<Product> gpus;

        public GPUSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.gpus = new List<Product>();
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
            return this.data.Products.Where(p => p.CategoryId == 4).Any();
        }

        public void seedData()
        {
            this.data.Products.AddRange(this.gpus);
            this.data.SaveChanges();
        }

        public void prepareData()
        {
            this.gpus.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/788241189.msi-geforce-rtx-3060-12gb-gddr6-192bit-rtx-3060-gaming-x-trio-12g.jpg",
                Platform = "Nvidia",
                Make = "MSI",
                Model = "RTX 3060",
                Price = 899,
                ReleasedYear=2020,
                MaxSpeed=1800,
                NumberOfFans=3,
                CategoryId = 4
            });

            this.gpus.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/801177513.powercolor-radeon-rx-6700xt-red-devil-12gb-oc-ddr6-axrx-6700xt-12gbd6-3dhe-oc.jpg",
                Platform = "AMD",
                Make = "Powercolor",
                Model = "Radeon RX 6700XT Red Devil",
                Price = 870,
                ReleasedYear=2021,
                MaxSpeed=1850,
                NumberOfFans=3,
                CategoryId = 4
            });
        }
    }
}
