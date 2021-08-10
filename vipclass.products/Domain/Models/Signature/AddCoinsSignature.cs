using System.ComponentModel.DataAnnotations;

namespace vipclass.products.Domain.Models.Signature
{
    public class AddCoinsSignature
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
