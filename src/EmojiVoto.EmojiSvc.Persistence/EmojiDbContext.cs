using EmojiVoto.EmojiSvc.Domain;
using EmojiVoto.EmojiSvc.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EmojiVoto.EmojiSvc.Persistence
{
    public class EmojiDbContext : DbContext
    {
        public DbSet<Emoji> Emojies { get; set; } = null!;

        public EmojiDbContext()
        {
            
        }

        public EmojiDbContext(DbContextOptions<EmojiDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmojiEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
