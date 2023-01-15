using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EmojiVoto.EmojiSvc.Api.Queries;

namespace EmojiVotoWPF.Voting.ViewModel;

public interface IVotingViewModel
{
    ObservableCollection<ListAllEmojisHandler.EmojiDto>? EmojiDtos { get; set; }
    Task GetEmojies();
}