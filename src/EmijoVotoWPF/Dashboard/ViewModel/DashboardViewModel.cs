using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using EmojiVotoWPF.Dashboard.Model;

namespace EmojiVotoWPF.Dashboard.ViewModel
{
    internal partial class DashboardViewModel: ObservableObject, IDashboardViewModel
    {
        private readonly IDashboardModel _model;

        [ObservableProperty] private ObservableCollection<Result> _votingResults = null!;

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
