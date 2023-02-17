using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVoto.Voting.Api.Commands;
using EmojiVoto.Voting.Application.Events;
using EmojiVotoWPF.Events;
using MediatR;

namespace EmojiVotoWPF.Voting.Model
{
    internal class VotingModel: IVotingModel
    {
        private readonly ISender _mediator;
        private readonly INewVoteCollector _collector;
        public event EventHandler<EmojiVotedEventArgs>? EmojiVoted;

        public VotingModel(ISender mediator, INewVoteCollector collector)
        {
            _mediator = mediator;
            _collector = collector;
            collector.Attach(this);
        }

        ~VotingModel()
        {
            _collector.Detach(this);
        }

        public async Task<IReadOnlyList<EmojiDto>> GetAllEmojis()
        {
            return (await _mediator.Send(new ListAllEmojisHandler.ListAllEmojis())).ToList().AsReadOnly();
        }

        public async Task Vote(string shortCode)
        {
            await _mediator.Send(new VoteEmojiHandler.VoteEmojiCommand { ShortCode = shortCode });
        }

        public async Task<EmojiDto> FindByShortCode(string shortCode)
        {
            return await _mediator.Send(new FindByShortCodeHandler.FindByShortcodeQuery { ShortCode = shortCode });
        }

        public async Task Update(NewVoteAdded notification, CancellationToken cancellationToken)
        {
            var emoji = await FindByShortCode(notification.ShortCode);
            OnEmojiVoted(new EmojiVotedEventArgs
            {
                ShortCode = emoji.Shortcode,
                UniCode = emoji.Unicode
            });
        }

        private void OnEmojiVoted(EmojiVotedEventArgs e)
        {
            EmojiVoted?.Invoke(this, e);
        }
    }
}
