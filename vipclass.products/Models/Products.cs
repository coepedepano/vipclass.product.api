using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vipclass.products.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Description { get; set; }
        public decimal Royalts { get; set; }
        public bool PutOnMarketPlace { get; set; }
        public int Active { get; set; }
        public TypeProduts TypeProduts { get; set; }
    }
}