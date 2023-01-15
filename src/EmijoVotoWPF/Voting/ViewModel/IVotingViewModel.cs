using EmojiVotoWPF.Voting.Model.Dto;
using System.Collections.ObjectModel;

namespace EmojiVotoWPF.Voting.ViewModel;

public interface IVotingViewModel
{
    ObservableCollection<EmojiDto>? EmojiDtos { get; set; }
}