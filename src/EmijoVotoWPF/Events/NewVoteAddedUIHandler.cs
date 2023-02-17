using System.Threading;
using System.Threading.Tasks;
using EmojiVoto.Voting.Application.Events;
using MediatR;

namespace EmojiVotoWPF.Events
{
    internal class NewVoteAddedUIHandler: INotificationHandler<NewVoteAdded>
    {
        private readonly INewVoteCollector _collector;

        public NewVoteAddedUIHandler(INewVoteCollector collector)
        {
            _collector = collector;
        }

        public async Task Handle(NewVoteAdded notification, CancellationToken cancellationToken)
        {
            await _collector.Notify(notification, cancellationToken);
        }
    }
}
