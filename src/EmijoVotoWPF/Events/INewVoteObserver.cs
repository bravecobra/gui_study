using System.Threading;
using System.Threading.Tasks;
using EmojiVoto.Voting.Application.Events;

namespace EmojiVotoWPF.Events;

public interface INewVoteObserver
{
    // Receive update from subject
    Task Update(NewVoteAdded notification, CancellationToken cancellationToken);
}