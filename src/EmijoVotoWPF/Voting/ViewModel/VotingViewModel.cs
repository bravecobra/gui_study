using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmojiVotoWPF.Voting.Model;
using EmojiVotoWPF.Voting.Model.Dto;

namespace EmojiVotoWPF.Voting.ViewModel
{
    internal partial class VotingViewModel : ObservableObject, IVotingViewModel
    {
        private readonly IVotingModel _model;

        [ObservableProperty]
        private ObservableCollection<EmojiDto>? _emojiDtos;

        [RelayCommand]
        private Task Vote(string shortCode)
        {
            return _model.Vote(shortCode);
        }

        public VotingViewModel(IVotingModel model)
        {
            _model = model;
            EmojiDtos = new ObservableCollection<EmojiDto>(_model.GetEmojisDtos());
        }
    }
}
