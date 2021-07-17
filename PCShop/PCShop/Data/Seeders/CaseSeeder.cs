using PCShop.Data.Models;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class CaseSeeder:ISeeder
    {
        public PCShopDbContext data;
        private List<Case> cases;

        public CaseSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.cases = new List<Case>();
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
            if (this.data.Cases.Any())
            {
                return true;
            }
            else return false;
        }

        public void seedData()
        {
            this.data.Cases.AddRange(this.cases);
            this.data.SaveChanges();
        }


        public void prepareData()
        {
            this.cases.Add(new Case
            {
                ImagePath = "https://p1.akcdn.net/full/680782590.be-quiet-pure-base-500dx-bgw37-bgw38.jpg",
                Make = "Be Quiet!",
                Model = "Pure Base 500DX",
                Size = "ATX",
                Price = 110.00
            });

           this.cases.Add(new Case
            {
                ImagePath = "https://p1.akcdn.net/full/599874924.asus-rog-strix-helios-gx601.jpg",
                Make = "Asus",
                Model = "ROG Strix Helios",
                Size = "ATX",
                Price = 250.00
            });

        }

        

    }
}
