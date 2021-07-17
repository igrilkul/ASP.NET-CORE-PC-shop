using PCShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class PSUSeeder : ISeeder
    {
        public PCShopDbContext data;
        private List<PSU> psus;

        public PSUSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.psus = new List<PSU>();
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
            if (this.data.PSUs.Any())
            {
                return true;
            }
            else return false;
        }

        public void seedData()
        {
            this.data.PSUs.AddRange(this.psus);
            this.data.SaveChanges();
        }

        public void prepareData()
        {
            throw new NotImplementedException();
        }
    }
}
