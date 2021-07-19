

namespace PCShop.Models.CPUs
{
    public class CPUsListViewModel
    {
        public int Id { get; init; }

        public string ImagePath { get; init; }

        public string Platform { get; init; }

        public string Model { get; init; }

        public string BoostFrequencies { get; init; }

        public double Price { get; init; }

        public int TDP { get; init; }

        public int ReleasedYear { get; init; }
    }
}
