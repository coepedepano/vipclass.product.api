using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vipclass.products.Models
{
    [Table("TypeProduts")]
    public class TypeProduts
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Description { get; set; }
    }
}