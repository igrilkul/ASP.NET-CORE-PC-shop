

using System.ComponentModel.DataAnnotations;

namespace PCShop.Data.Models
{
    public class RAM
    {
        public int Id { get; init; }

        public string ImagePath { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Size { get; set; }

        public int NumberOfSticks { get; set; }

        public string Timings { get; set; }
        [Required]
        public double Price { get; set; }

        public int ReleasedYear { get; set; }
    }
}
