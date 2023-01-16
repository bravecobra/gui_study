using EmojiVoto.Voting.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmojiVoto.Voting.Persistence.Mappings
{
    internal class VotingResultEntityConfiguration: IEntityTypeConfiguration<VotingResult>
    {
        public void Configure(EntityTypeBuilder<VotingResult> builder)
        {
            builder.HasKey(votingresult => votingresult.Shortcode);
        }
    }
}
