using Microsoft.EntityFrameworkCore;
using PCShop.Data.Seeders;


namespace PCShop.Data
{
    public class InitialDataSeeder
    {
        public PCShopDbContext data;

        public InitialDataSeeder(PCShopDbContext data)
        {
            this.data = data;
            
        }

        public void StartSeeding()
        {
            var adminSeeder = new AdminSeeder(this.data);
            var categorySeeder = new CategorySeeder(this.data);
            var caseSeeder = new CaseSeeder(this.data);
            var cpuCoolerSeeder = new CPUCoolerSeeder(this.data);
            var cpuSeeder = new CPUSeeder(this.data);
            var gpuSeeder = new GPUSeeder(this.data);
            var motherboardSeeder = new MotherboardSeeder(this.data);
            var psuSeeder = new PSUSeeder(this.data);
            var ramSeeder = new RAMSeeder(this.data);

            adminSeeder.start();
            categorySeeder.start();
            caseSeeder.start();
            cpuCoolerSeeder.start();
            cpuSeeder.start();
            gpuSeeder.start();
            motherboardSeeder.start();
            psuSeeder.start();
            ramSeeder.start();
        }
        
    }
}
