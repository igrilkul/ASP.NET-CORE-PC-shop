using System.ComponentModel.DataAnnotations;


namespace PCShop.Data.Models
{
    public class CPU
    {
        public int Id { get; init; }

        public string ImagePath { get; set; }

        public string Platform { get; set; }

        public string Model { get; set; }

        public string BoostFrequencies { get; set; }

        public int TDP { get; set; }
        [Required]
        public double Price { get; set; }

        public int ReleasedYear { get; set; }
    }
}
