using Microsoft.EntityFrameworkCore;

namespace PostgresTypesBenchmark
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TestGuid> TestGuids { get; set; }
        public DbSet<TestInt> TestInts { get; set; }
        public DbSet<TestLong> TestLongs { get; set; }
        public DbSet<TestGuidDefault> TestGuidDefaults { get; set; }
    }
}