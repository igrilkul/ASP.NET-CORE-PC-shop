using Microsoft.EntityFrameworkCore;
using PCShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCShop.Test.Mocks
{
    public class DatabaseMock
    {
        public static PCShopDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<PCShopDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new PCShopDbContext(dbContextOptions);
            }
        }
    }
}
