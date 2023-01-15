using EmojiVotoWPF.Voting.Model.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmojiVotoWPF.Voting.Model;

internal interface IVotingModel
{
    IReadOnlyList<EmojiDto> GetEmojisDtos();
    Task Vote(string shortCode);
}