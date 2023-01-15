using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVotoWPF.Voting.Model;

namespace EmojiVotoWPF.Voting.ViewModel
{
    internal partial class VotingViewModel : ObservableObject, IVotingViewModel
    {
        private readonly IVotingModel _model;

        [ObservableProperty]
        private ObservableCollection<ListAllEmojisHandler.EmojiDto>? _emojiDtos;

        [RelayCommand]
        private Task Vote(string shortCode)
        {
            return _model.Vote(shortCode);
        }

        public async Task GetEmojies()
        {
            EmojiDtos = new ObservableCollection<ListAllEmojisHandler.EmojiDto>(await _model.GetAllEmojis());
        }

        public VotingViewModel(IVotingModel model)
        {
            _model = model;
        }
    }
}
