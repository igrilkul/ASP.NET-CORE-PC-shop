using System.ComponentModel.DataAnnotations;


namespace PCShop.Data.Models
{
    public class GPU
    {
        public int Id { get; init; }

        public string ImagePath { get; set; }

        public string Platform { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }
        [Required]
        public double Price { get; set; }

        public int ReleasedYear { get; set; }
    }
}
