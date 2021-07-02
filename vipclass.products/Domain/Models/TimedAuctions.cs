using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vipclass.products.Domain.Models
{
    [Table("Products")]
    public class TimedAuctions
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int IdProduct { get; set; }
        public decimal MinimumBid { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}