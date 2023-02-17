using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVotoWPF.Voting.Model;
using Notifications.Wpf.Core;

namespace EmojiVotoWPF.Voting.ViewModel
{
    internal partial class VotingViewModel : ObservableObject, IVotingViewModel
    {
        private readonly IVotingModel _model;

        [ObservableProperty]
        private ObservableCollection<EmojiDto>? _emojiDtos;

        private readonly INotificationManager _notificationManager;

        [RelayCommand]
        public Task Vote(string shortCode)
        {
            return _model.Vote(shortCode);
        }

        public async Task GetEmojies()
        {
            EmojiDtos = new ObservableCollection<EmojiDto>(await _model.GetAllEmojis());
        }

        public VotingViewModel(IVotingModel model, INotificationManager notificationManager)
        {
            _model = model;
            _model.EmojiVoted += ModelOnEmojiVoted;
            _notificationManager = notificationManager;
        }

        private void ModelOnEmojiVoted(object? sender, EmojiVotedEventArgs e)
        {
            _notificationManager.ShowAsync(new NotificationContent
            {
                Message = $"Your vote for {e.UniCode} has been registered!"
            });
        }

        public string Title => "Voting";
    }
}
