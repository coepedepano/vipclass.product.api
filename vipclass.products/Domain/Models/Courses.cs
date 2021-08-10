using System.ComponentModel.DataAnnotations;

namespace vipclass.products.Domain.Models
{
    public class Courses
    {
        public int IdCourse { get; set; }
        public int IdCategorie { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte ImageCover { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
    }
}