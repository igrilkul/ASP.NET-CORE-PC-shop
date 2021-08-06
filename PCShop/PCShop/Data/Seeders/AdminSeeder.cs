using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Data.Seeders
{
    public class AdminSeeder : ISeeder
    {
        public PCShopDbContext data;
        
        public AdminSeeder(PCShopDbContext data)
        {
            this.data = data;
        }

        public void start()
        {
            throw new NotImplementedException();
        }

        public bool checkData()
        {
            if(this.data.Users.Any(x=>x.IsInRole("Administrator")))
        }

        public void prepareData()
        {
            throw new NotImplementedException();
        }

        public void seedData()
        {
            throw new NotImplementedException();
        }

       
    }
}
