using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            dbContextOptionsBuilder.UseSqlServer("Server=localhost,1433;Database=TestTaskDb;User Id=SA;Password=1234567890Qwerty@;MultipleActiveResultSets=True;TrustServerCertificate=True");

            return new DatabaseContext(dbContextOptionsBuilder.Options);
        }
    }
}
