using System.ComponentModel.DataAnnotations;

namespace vipclass.products.Domain.Models
{
    public class Coins
    {
        public int IdCoin { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}