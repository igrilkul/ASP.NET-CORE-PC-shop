

namespace PCShop.Data.Seeders
{
   public interface ISeeder
    {
        void start();
        bool checkData();

        void seedData();

        void prepareData();

    }
}
