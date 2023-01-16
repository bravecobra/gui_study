using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVoto.Voting.Api.Queries;
using EmojiVotoWPF.Dashboard.Model;
using static EmojiVoto.EmojiSvc.Api.Queries.ListAllEmojisHandler;

namespace EmojiVotoWPF.Dashboard.ViewModel
{
    internal partial class DashboardViewModel: ObservableObject, IDashboardViewModel
    {
        private readonly IDashboardModel _model;

        [ObservableProperty]
        private ObservableCollection<Result> _VotingResults;

        public DashboardViewModel(IDashboardModel model)
        {
            _model = model;
        }
        public string Title => "Dashboard";

        public async Task GetResults()
        {
            VotingResults = new ObservableCollection<Result>(await _model.GetVotingResults());
        }
    }
}
