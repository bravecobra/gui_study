using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVoto.Voting.Application.Events;
using EmojiVotoWPF.Voting.Model;
using MediatR;
using ToastNotifications;
using ToastNotifications.Messages;

namespace EmojiVotoWPF.Voting.ViewModel
{
    internal partial class VotingViewModel : ObservableObject, IVotingViewModel, INotificationHandler<NewVoteAdded>
    {
        private readonly IVotingModel _model;

        [ObservableProperty]
        private ObservableCollection<EmojiDto>? _emojiDtos;

        private readonly INotifier _notifier;

        [RelayCommand]
        public Task Vote(string shortCode)
        {
            return _model.Vote(shortCode);
        }

        public async Task GetEmojies()
        {
            EmojiDtos = new ObservableCollection<EmojiDto>(await _model.GetAllEmojis());
        }

        public VotingViewModel(IVotingModel model, INotifier notifier)
        {
            _model = model;
            _notifier = notifier;
        }

        public string Title => "Voting";

        public async Task Handle(NewVoteAdded notification, CancellationToken cancellationToken)
        {
            var emoji = await _model.FindByShortCode(notification.ShortCode);
            _notifier.ShowSuccess($"Your vote for {emoji.Unicode} has been registered!");
        }
    }
}
