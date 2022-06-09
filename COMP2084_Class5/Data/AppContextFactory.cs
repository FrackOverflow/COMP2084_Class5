using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace COMP2084_Class5.Data
{
    public class AppContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] arg)
        {
            var optBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optBuilder.UseSqlServer("");
            return new ApplicationDbContext(optBuilder.Options);
        }
    }
}
