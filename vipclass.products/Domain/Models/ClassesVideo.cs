using System;
using System.ComponentModel.DataAnnotations;

namespace vipclass.products.Domain.Models
{
    public class ClassesVideo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Url { get; set; }
        public bool Active { get; set; }
    }
}
