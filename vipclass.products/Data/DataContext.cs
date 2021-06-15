using Microsoft.EntityFrameworkCore;
using vipclass.products.Models;

namespace vipclass.products.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<AccessKeys> AccessKeys { get; set; }
        public DbSet<FileProducts> FileProducts { get; set; }
        public DbSet<FixedPrice> FixedPrice { get; set; }
        public DbSet<TimedAuctions> TimedAuctions { get; set; }
        public DbSet<TypeProduts> TypeProduts { get; set; }
        public DbSet<UnlimitedAuctions> UnlimitedAuctions { get; set; }
    }
}
