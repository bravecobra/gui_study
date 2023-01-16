using EmojiVoto.Voting.Domain;
using EmojiVoto.Voting.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EmojiVoto.Voting.Persistence
{
    public class VotingDbContext : DbContext
    {
        public DbSet<VotingResult> VotingResults { get; set; } = null!;
        public string DbPath { get; private set; } = null!;

        public VotingDbContext()
        {

        }

        public VotingDbContext(DbContextOptions<VotingDbContext> options) : base(options)
        {
            DbPath = "voting.db";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VotingResultEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}