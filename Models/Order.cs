using System;
using System.ComponentModel.DataAnnotations;

namespace ProductOrder_application.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int StaffId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total Amount must be greater than 0.")]
        public decimal TotalAmount { get; set; }
        public int Id { get; internal set; }
    }
}
 