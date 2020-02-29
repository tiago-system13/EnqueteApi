using EnqueteApi.Core.Entity;
using EnqueteApi.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EnqueteApi.Data.Context
{
    public class EnqueteApiContext : DbContext
    {
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Option> Options { get; set; }
        

        public EnqueteApiContext(DbContextOptions<EnqueteApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PollMapping());
            modelBuilder.ApplyConfiguration(new OptionMapping());
        }
    }
}
