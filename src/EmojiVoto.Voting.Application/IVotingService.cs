using EmojiVoto.Voting.Domain;

namespace EmojiVoto.Voting.Application
{
    public interface IVotingService
    {
        Task Vote(string choice, CancellationToken cancellationToken);
        Task<List<VotingResult>> Results(CancellationToken cancellationToken);
    }
}