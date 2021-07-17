using PCShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class RAMSeeder : ISeeder
    {
        public PCShopDbContext data;
        private List<RAM> rams;

        public RAMSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.rams = new List<RAM>();
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
            if (this.data.RAMs.Any())
            {
                return true;
            }
            else return false;
        }

        public void seedData()
        {
            this.data.RAMs.AddRange(this.rams);
            this.data.SaveChanges();
        }

        public void prepareData()
        {
            throw new NotImplementedException();
        }
    }
}
