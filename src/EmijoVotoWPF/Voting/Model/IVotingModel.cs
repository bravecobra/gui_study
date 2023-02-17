using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVotoWPF.Events;

namespace EmojiVotoWPF.Voting.Model;

public interface IVotingModel: INewVoteObserver
{
    Task<IReadOnlyList<EmojiDto>> GetAllEmojis();
    Task Vote(string shortCode);
    Task<EmojiDto> FindByShortCode(string shortCode);
    event EventHandler<EmojiVotedEventArgs> EmojiVoted;
}