using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackEndv2.Data
{
    public class PerfumeDetailContext : IdentityDbContext<User>
    {
        public PerfumeDetailContext(DbContextOptions<PerfumeDetailContext> opt) : base(opt) { }


        #region Dbset
        public DbSet<PerfumeDetail> Perfumes { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<ShippingAddress> ShippingAddress { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Cart> Cart { get; set; }
        #endregion
    }
}
