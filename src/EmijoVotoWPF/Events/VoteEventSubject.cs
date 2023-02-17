using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmojiVoto.Voting.Application.Events;
using Microsoft.Extensions.Logging;

namespace EmojiVotoWPF.Events
{
    internal class VoteEventSubject: INewVoteCollector
    {
        private readonly ILogger<VoteEventSubject> _logger;

        public VoteEventSubject(ILogger<VoteEventSubject> logger)
        {
            _logger = logger;
        }
        private readonly List<INewVoteObserver> _observers = new();

        public void Attach(INewVoteObserver newVoteObserver)
        {
            _logger.LogInformation("Subject: Attached an observer.");
            _observers.Add(newVoteObserver);
        }

        public void Detach(INewVoteObserver newVoteObserver)
        {
            _observers.Remove(newVoteObserver);
            _logger.LogInformation("Subject: Detached an observer.");
        }

        public async Task Notify(NewVoteAdded notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Subject: Notifying observers...");
            foreach (var observer in _observers)
            {
                await observer.Update(notification, cancellationToken);
            }
        }
    }
}
