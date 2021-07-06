using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vipclass.products.Domain.Models
{
    [Table("Products")]
    public class Products
    {
        public int Id { get; set; }
        public int IdCategories { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Description { get; set; }
        public decimal Royalts { get; set; }
        public bool PutOnMarketPlace { get; set; }
        public bool Active { get; set; }
    }
}