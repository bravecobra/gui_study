namespace EmojiVoto.Voting.Domain
{
    public class VotingResult
    {
        public string Shortcode { get; init; } = null!;
        public int Votes { get; set; }
    }
}