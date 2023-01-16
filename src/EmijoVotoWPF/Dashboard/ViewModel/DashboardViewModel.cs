using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using EmojiVoto.Voting.Application.Events;
using EmojiVotoWPF.Dashboard.Model;
using MediatR;

namespace EmojiVotoWPF.Dashboard.ViewModel
{
    internal partial class DashboardViewModel: ObservableObject, IDashboardViewModel, INotificationHandler<NewVoteAdded>
    {
        private readonly IDashboardModel _model;

        [ObservableProperty] private ObservableCollection<Result> _VotingResults = null!;

        public DashboardViewModel(IDashboardModel model)
        {
            _model = model;
        }
        public string Title => "Dashboard";

        public async Task GetResults()
        {
            VotingResults = new ObservableCollection<Result>(await _model.GetVotingResults());
        }

        /// <summary>
        /// When a new vote has been cast, get the latest voting result again.
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(NewVoteAdded notification, CancellationToken cancellationToken)
        {
            VotingResults = new ObservableCollection<Result>(await _model.GetVotingResults());
        }
    }
}
