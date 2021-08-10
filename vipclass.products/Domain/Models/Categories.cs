using System.ComponentModel.DataAnnotations;

namespace vipclass.products.Domain.Models
{
    public class Categories
    {
        public int IdCategorie { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}