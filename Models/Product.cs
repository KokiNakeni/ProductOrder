using System.ComponentModel.DataAnnotations;

namespace ProductOrder_application.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductTitle { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(100)]
        public byte[] Image { get; set; }
    }
}
