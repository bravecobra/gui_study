using EmojiVoto.EmojiSvc.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmojiVoto.EmojiSvc.Persistence.Mappings
{
    internal class EmojiEntityConfiguration: IEntityTypeConfiguration<Emoji>
    {
        public void Configure(EntityTypeBuilder<Emoji> builder)
        {
            builder.HasKey(emoji => emoji.Shortcode);
        }
    }
}
