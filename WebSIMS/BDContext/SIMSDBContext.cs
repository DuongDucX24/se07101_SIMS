using Microsoft.EntityFrameworkCore;
using WebSIMS.BDContext.Entities;

namespace WebSIMS.BDContext
{
    public class SIMSDBContext : DbContext
    {
        public SIMSDBContext(DbContextOptions<SIMSDBContext> options) : base(options) { }

        public DbSet<Courses> CoursesDb { get; set; }
        public DbSet<Users> UsersDb { get; set; }
    }
}
