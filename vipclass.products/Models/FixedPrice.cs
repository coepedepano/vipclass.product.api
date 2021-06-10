using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vipclass.products.Models
{
    [Table("FixedPrice")]
    public class FixedPrice
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Range(1, int.MaxValue, ErrorMessage = "The value must be greater than zero")]
        public decimal Price { get; set; }
    }
}