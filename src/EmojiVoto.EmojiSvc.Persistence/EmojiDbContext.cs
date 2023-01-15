using EmojiVoto.EmojiSvc.Domain;
using EmojiVoto.EmojiSvc.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EmojiVoto.EmojiSvc.Persistence
{
    public class EmojiDbContext : DbContext
    {
        public DbSet<Emoji> Emojies { get; set; } = null!;
        public string DbPath { get; private set; } = null!;

        public EmojiDbContext()
        {
            
        }

        public EmojiDbContext(DbContextOptions<EmojiDbContext> options) : base(options)
        {
            DbPath = "emojies.db";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmojiEntityConfiguration());
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
