using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EmojiVoto.EmojiSvc.Api.Queries;

namespace EmojiVotoWPF.Voting.ViewModel;

public interface IVotingViewModel: IMenuItem
{
    ObservableCollection<EmojiDto>? EmojiDtos { get; set; }
    Task GetEmojies();
}