using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BaseDbContext>
    {
        public BaseDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BaseDbContext>();

            // Burada connection string'i doğrudan yazıyoruz.
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DGS;Trusted_Connection=True;");

            // IConfiguration null gönderiyoruz, çünkü artık config okumuyoruz.
            return new BaseDbContext(optionsBuilder.Options, null);
        }
    }
}
