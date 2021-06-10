using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vipclass.products.Models
{
    [Table("AccessKeys")]
    public class AccessKeys
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int IdProduct { get; set; }
        public string Key { get; set; }
    }
}