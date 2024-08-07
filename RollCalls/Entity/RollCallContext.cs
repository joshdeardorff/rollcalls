using Microsoft.EntityFrameworkCore;
using RollCalls.Pages;

namespace RollCalls.Entity
{
    public class RollCallContext : DbContext
    {
        public RollCallContext(DbContextOptions<RollCallContext> options) : base(options) { }

        public DbSet<Submission> Submissions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
