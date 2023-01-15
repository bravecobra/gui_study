using System.Collections.Generic;
using System.Threading.Tasks;
using EmojiVoto.EmojiSvc.Api.Queries;

namespace EmojiVotoWPF.Voting.Model;

internal interface IVotingModel
{
    Task<IReadOnlyList<ListAllEmojisHandler.EmojiDto>> GetAllEmojis();
    Task Vote(string shortCode);
}