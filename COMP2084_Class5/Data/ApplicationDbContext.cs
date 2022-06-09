using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using COMP2084_Class5.Models;

namespace COMP2084_Class5.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<COMP2084_Class5.Models.Car>? Car { get; set; }
        public DbSet<COMP2084_Class5.Models.Engine>? Engine { get; set; }
    }
}