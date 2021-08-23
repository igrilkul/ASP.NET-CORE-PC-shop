using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Data.Seeders
{
    public class AdminSeeder
    {
        public PCShopDbContext data;

        public AdminSeeder(PCShopDbContext data)
        {
            this.data = data;
        }

        public void start()
        {
            AddRole("User").Wait();
            string adminRoleId = AddRole("Administrator").GetAwaiter().GetResult();

            string adminUserId = AddUser("admin@abv.bg", "admin@abv.bg", "Magazin1!");

            SetAdminRoleToUser(adminUserId, adminRoleId);
        }

        public async Task<string> AddRole(string name)
        {
                var roleStore = new RoleStore<IdentityRole>(this.data);

            if (!this.data.Roles.Any(r => r.Name == name))
            {
                var role = new IdentityRole(name);
                await roleStore.CreateAsync(role);
                this.data.SaveChanges();

                return role.Id;
            }
            else
            {
                return this.data.Roles.Where(x=>x.Name==name).FirstOrDefault().Id;
            }
        }

        public string AddUser( string name,string email,string password)
        {
            
            if (!this.data.Users.Any(x=>x.Email == email))
            {
                PasswordHasher<User> ph = new PasswordHasher<User>();

                var user = new User
                {
                    UserName = name,
                    NormalizedUserName = name.ToUpper(),
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    EmailConfirmed = true
                };

                user.PasswordHash = ph.HashPassword(user, password);
                this.data.Users.Add(user);
                this.data.SaveChanges();

                return user.Id;
            }
            else
            {
                return this.data.Users.Where(x => x.Email == email).FirstOrDefault().Id;
            }
        }

        public void SetAdminRoleToUser(string userId, string roleId)
        {
            if(!this.data.UserRoles.Any(x=>x.RoleId==roleId && x.UserId == userId))
            {
                this.data.UserRoles.Add(new IdentityUserRole<string>
                {
                    RoleId = roleId,
                    UserId = userId
                });

                this.data.SaveChanges();
            }
        }

    }
}
