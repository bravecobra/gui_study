﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVoto.Voting.Api.Commands;
using MediatR;

namespace EmojiVotoWPF.Voting.Model
{
    internal class VotingModel: IVotingModel
    {
        private readonly IMediator _mediator;
        private List<EmojiDto> _emojis = new();

        public VotingModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IReadOnlyList<EmojiDto>> GetAllEmojis()
        {
            _emojis = (await _mediator.Send(new ListAllEmojisHandler.ListAllEmojis())).ToList();
            return _emojis.AsReadOnly();
        }

        public async Task Vote(string shortCode)
        {
            await _mediator.Send(new VoteEmojiHandler.VoteEmojiCommand { ShortCode = shortCode });
        }

        public async Task<EmojiDto> FindByShortCode(string shortCode)
        {
            return await _mediator.Send(new FindByShortCodeHandler.FindByShortcodeQuery() { ShortCode = shortCode });
        }
    }
}
