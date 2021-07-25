using PCShop.Data.Models;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class CaseSeeder:ISeeder
    {
        public PCShopDbContext data;
        private List<Product> cases;

        public CaseSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.cases = new List<Product>();
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
            return this.data.Products.Where(p => p.CategoryId == 1).Any();
        }

        public void seedData()
        {
            this.data.Products.AddRange(this.cases);
            this.data.SaveChanges();
        }


        public void prepareData()
        {
            this.cases.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/680782590.be-quiet-pure-base-500dx-bgw37-bgw38.jpg",
                Make = "Be Quiet!",
                Model = "Pure Base 500DX",
                Size = "ATX",
                Price = 110.00,
                ReleasedYear=2018,
                CategoryId=1
            });

           this.cases.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/599874924.asus-rog-strix-helios-gx601.jpg",
                Make = "Asus",
                Model = "ROG Strix Helios",
                Size = "ATX",
                Price = 250.00,
                ReleasedYear=2019,
                CategoryId = 1
           });

        }

        

    }
}
