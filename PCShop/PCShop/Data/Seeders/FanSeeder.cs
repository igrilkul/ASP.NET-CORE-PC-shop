using PCShop.Data.Models;
using System.Collections.Generic;
using System.Linq;


namespace PCShop.Data.Seeders
{
    public class FanSeeder : ISeeder
    {
        public PCShopDbContext data;
        private List<Fan> fans;

        public FanSeeder(PCShopDbContext data)
        {
            this.data = data;
            this.fans = new List<Fan>();
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
            if (this.data.Fans.Any())
            {
                return true;
            }
            else return false;
        }

        public void seedData()
        {
            this.data.Fans.AddRange(this.fans);
            this.data.SaveChanges();
        }

        public void prepareData()
        {
            this.fans.Add(new Fan
            {
                ImagePath = "https://p1.akcdn.net/full/499180135.noctua-nf-a12x25-pwm.jpg",
                Make = "Noctua",
                Model = "NF-A12",
                Price = 25
            });

            this.fans.Add(new Fan
            {
                ImagePath = "https://p1.akcdn.net/full/799543380.lian-li-uni-sl140-argb-ll-fan-luli-018-9.jpg",
                Make = "Lian Li",
                Model = "UNI SL140",
                Price = 25
            });
        }


    }
}
