using System.Collections.Generic;

namespace vipclass.products.Domain.Models.Signature
{
    public class AddCourseSignature
    {
        public int IdCategorie { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte ImageCover { get; set; }
        public decimal Price { get; set; }
        public AddProducerSignature Producer { get; set; }
        public List<AddCoProducerSignature> CoProducer { get; set; }
        public bool Active { get; set; }
    }
}
