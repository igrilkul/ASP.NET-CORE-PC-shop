using System.ComponentModel.DataAnnotations;


namespace PCShop.Data.Models
{
    public class Case
    {
        public int Id { get; init; }

        public string ImagePath { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Size { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
