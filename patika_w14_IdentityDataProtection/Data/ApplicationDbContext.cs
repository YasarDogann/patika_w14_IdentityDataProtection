using Microsoft.EntityFrameworkCore;
using patika_w14_IdentityDataProtection.Models;

namespace patika_w14_IdentityDataProtection.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
