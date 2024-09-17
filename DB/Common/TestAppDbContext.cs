using Microsoft.EntityFrameworkCore;
using TestWebApplication.DB.Models;
using TestWebApplication.Models;

namespace TestWebApplication.DB.Common
{
    public class TestAppDbContext : DbContext
    {
        public TestAppDbContext()
        {
        }

        public TestAppDbContext(DbContextOptions<TestAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
    }
}
