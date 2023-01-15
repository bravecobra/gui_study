using EmojiVoto.Voting.Domain;

namespace EmojiVoto.Voting.Application
{
    public interface IVotingRepository
    {
        Task<VotingResult?> GetResultByShortcode(string shortcode);
        Task<bool> AddVote(VotingResult result);
        Task<bool> UpdateVote(VotingResult result);
        Task<IEnumerable<VotingResult>> GetResults();
    }
}
