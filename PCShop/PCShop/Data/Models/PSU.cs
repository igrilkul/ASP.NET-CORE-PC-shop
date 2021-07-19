

using System.ComponentModel.DataAnnotations;

namespace PCShop.Data.Models
{
    public class PSU
    {
        public int Id { get; init; }

        public string ImagePath { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Power { get; set; }

        public string Efficiency { get; set; }
        [Required]
        public double Price { get; set; }

        public int ReleasedYear { get; set; }
    }
}
