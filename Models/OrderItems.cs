using System.ComponentModel.DataAnnotations;

namespace ProductOrder_application.Models
{
    public class OrderItems
    {
        [Key]
         public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }
        
        public decimal TotalAmount { get; internal set; }
    }
}
//Data validation is good for assisting our system to work with accurate information.
