using Microsoft.EntityFrameworkCore;

namespace BackEndv2.Data
{
    public class PerfumeDetailContext : DbContext
    {
        public PerfumeDetailContext(DbContextOptions<PerfumeDetailContext> opt) : base(opt) { }


        #region Dbset
        public DbSet<PerfumeDetail> Perfumes { get; set; }
        #endregion
    }
}
