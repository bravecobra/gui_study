using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmojiVotoWPF.Voting.Model.Dto;
using Microsoft.Extensions.Logging;

namespace EmojiVotoWPF.Voting.Model
{
    internal class VotingModel: IVotingModel
    {
        private readonly ILogger<VotingModel> _logger;
        private readonly List<EmojiDto> _emojis = new();

        public VotingModel(ILogger<VotingModel> logger)
        {
            _logger = logger;
            foreach (var s in EmojiDefinitions.Top100Emojis)
            {
                _emojis.Add(new EmojiDto
                {
                    Shortcode = s,
                    Unicode = EmojiDefinitions.CodeMap[s]
                });
            }
        }

        public IReadOnlyList<EmojiDto> GetEmojisDtos()
        {
            return _emojis.AsReadOnly();
        }

        public Task Vote(string shortCode)
        {
            _logger.LogInformation($"You voted for {shortCode}");
            return Task.CompletedTask;
        }
    }
}
