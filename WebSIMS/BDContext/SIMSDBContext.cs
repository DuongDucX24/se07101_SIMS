using Microsoft.EntityFrameworkCore;
using WebSIMS.BDContext.Entities;

namespace WebSIMS.BDContext
{
    public class SIMSDBContext : DbContext
    {
        public SIMSDBContext(DbContextOptions<SIMSDBContext> options) : base(options) { }

        public DbSet<Courses> Courses { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
