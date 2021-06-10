using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vipclass.products.Models
{
    [Table("FileProducts")]
    public class FileProducts
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int IdProduct { get; set; }
        public string Url { get; set; }
        public string Hash { get; set; }
        public bool Active { get; set; }
    }
}