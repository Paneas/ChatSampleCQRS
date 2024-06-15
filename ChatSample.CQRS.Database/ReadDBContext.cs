using ChatSample.CQRS.Model.Read;
using Microsoft.EntityFrameworkCore;


namespace ChatSample.CQRS.Database
{
    public class ReadDBContext : DbContext
    {
        public ReadDBContext(DbContextOptions<ReadDBContext> options)
            : base(options)
        {
        }
        public DbSet<MessagesReadModel> Messages { get; set; }
    }
}
