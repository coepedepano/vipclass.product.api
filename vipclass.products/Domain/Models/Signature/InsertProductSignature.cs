using System;
namespace vipclass.products.Domain.Models.Signature
{
    public class InsertProductSignature
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Royalts { get; set; }
        public bool PutOnMarketPlace { get; set; }
        public int Active { get; set; }
        public int IdCategories { get; set; }
    }
}
