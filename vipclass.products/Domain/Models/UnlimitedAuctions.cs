using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vipclass.products.Domain.Models
{
    [Table("UnlimitedAuctions")]
    public class UnlimitedAuctions
    {
        [Key]
        public int Id { get; set; }
        public int IdProduct { get; set; }
    }
}