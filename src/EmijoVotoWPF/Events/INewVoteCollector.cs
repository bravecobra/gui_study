using System.Threading;
using System.Threading.Tasks;
using EmojiVoto.Voting.Application.Events;

namespace EmojiVotoWPF.Events;

public interface INewVoteCollector
{
    // Attach an observer to the subject.
    void Attach(INewVoteObserver newVoteObserver);

    // Detach an observer from the subject.
    void Detach(INewVoteObserver newVoteObserver);

    // Notify all observers about an event.
    Task Notify(NewVoteAdded notification, CancellationToken cancellationToken);
}