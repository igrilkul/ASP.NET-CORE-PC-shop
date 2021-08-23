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

            this.cases.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/753479022.corsair-4000d-airflow-cc-9011201.jpg",
                Make = "Corsair",
                Model = "4000D Airflow",
                Size = "ATX",
                Price = 80.00,
                ReleasedYear = 2018,
                CategoryId = 1
            });

            this.cases.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/599874924.asus-rog-strix-helios-gx601.jpg",
                Make = "Asus",
                Model = "ROG Strix Helios",
                Size = "ATX",
                Price = 250.00,
                ReleasedYear = 2019,
                CategoryId = 1
            });

            this.cases.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/488756789.fractal-design-meshify-c-dark-tg-fd-ca-mesh-c-bko-tgl.jpg",
                Make = "Fractal Design",
                Model = "Meshify C",
                Size = "ATX",
                Price = 85.00,
                ReleasedYear = 2017,
                CategoryId = 1
            });

            this.cases.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/773207670.phanteks-eclipse-p360a-tg-phanteks-case-geph-130.jpg",
                Make = "Phanteks",
                Model = "Eclipse P360A TG",
                Size = "Micro ATX",
                Price = 75.00,
                ReleasedYear = 2019,
                CategoryId = 1
            });

            this.cases.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/578776983.deepcool-matrexx-30.jpg",
                Make = "Deepcool",
                Model = "Matrexx 30",
                Size = "ATX",
                Price = 20.00,
                ReleasedYear = 2013,
                CategoryId = 1
            });

            this.cases.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/530397795.lian-li-pc-o11dw-tg-geli-808.jpg",
                Make = "Lian Li",
                Model = "PC-O11DW TG",
                Size = "ATX",
                Price = 150.00,
                ReleasedYear = 2020,
                CategoryId = 1
            });

        }

        

    }
}
