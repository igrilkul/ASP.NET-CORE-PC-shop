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
            var caseSeeder = new CaseSeeder(this.data);
            var cpuCoolerSeeder = new CPUCoolerSeeder(this.data);
            var cpuSeeder = new CPUSeeder(this.data);
            var fanSeeder = new FanSeeder(this.data);
            var gpuSeeder = new GPUSeeder(this.data);
            var motherboardSeeder = new MotherboardSeeder(this.data);
            var psuSeeder = new PSUSeeder(this.data);
            var ramSeeder = new RAMSeeder(this.data);

            caseSeeder.start();
            cpuCoolerSeeder.start();
            cpuSeeder.start();
            fanSeeder.start();
            gpuSeeder.start();
            motherboardSeeder.start();
            psuSeeder.start();
            ramSeeder.start();
        }
        
    }
}
