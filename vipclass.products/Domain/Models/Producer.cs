using System.ComponentModel.DataAnnotations;

namespace vipclass.products.Domain.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Wallet { get; set; }
        [Required(ErrorMessage = "Required field")]
        public decimal Royalts { get; set; }
        public bool Active { get; set; }
    }
}