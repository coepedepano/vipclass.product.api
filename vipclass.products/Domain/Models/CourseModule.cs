using System;
using System.ComponentModel.DataAnnotations;

namespace vipclass.products.Domain.Models
{
    public class CourseModule
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Description { get; set; }
        public ClassesModule ClassesModule { get; set; }
        public bool Active { get; set; }
    }
}
