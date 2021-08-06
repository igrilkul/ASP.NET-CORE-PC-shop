using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Data.Seeders
{
    public class RoleSeeder
    {
        public PCShopDbContext data;

        public RoleSeeder(PCShopDbContext data)
        {
            this.data = data;
            
        }


        public void start()
        {

            string[] roles = new string[] { "User", "Administrator"};

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(this.data);

                if (!this.data.Roles.Any(r => r.Name == role))
                {
                    roleStore.CreateAsync(new IdentityRole(role));
                }
            }

             this.data.SaveChanges();
        }
        
    }
}

