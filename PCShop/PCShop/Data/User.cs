using Microsoft.AspNetCore.Identity;
using PCShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Data
{
    public class User :IdentityUser
    {
        public Cart Cart { get; init; }
    }
}
