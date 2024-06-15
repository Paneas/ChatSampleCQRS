using Microsoft.EntityFrameworkCore;
using ChatSample.CQRS.Model.Write;

namespace ChatSample.CQRS.Database
{
    public class WriteDBContext : DbContext
    {
        public WriteDBContext(DbContextOptions<WriteDBContext> options)
            : base(options)
        {
        }

        public DbSet<Messages> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Messages>().HasKey(c => c.Id);

            base.OnModelCreating(modelBuilder);
        }

    }
}
