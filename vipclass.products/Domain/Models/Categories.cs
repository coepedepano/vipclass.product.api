using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vipclass.products.Domain.Models
{
    [Table("Categories")]
    public class Categories
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}