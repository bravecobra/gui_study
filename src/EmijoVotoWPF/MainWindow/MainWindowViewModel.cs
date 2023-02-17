using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using EmojiVotoWPF.Dashboard.ViewModel;
using EmojiVotoWPF.Voting.ViewModel;

namespace EmojiVotoWPF.MainWindow
{
    internal partial class MainWindowViewModel: ObservableObject, IMainWindowViewModel
    {
        public ObservableCollection<IMenuItem> MenuItems { get; }

        [ObservableProperty]
        private object? _selectedItem;

        /// <summary>
        /// When the selecteditem from the left menu is changed, then leftdrawer will be closed
        /// </summary>
        /// <param name="value"></param>
        partial void OnSelectedItemChanged(object? value)
        {
            IsMenuOpen = false;
        }

        [ObservableProperty]
        private bool _isMenuOpen;

        public MainWindowViewModel(IVotingViewModel votingViewModel, IDashboardViewModel dashboardViewModel)
        {
            MenuItems = new ObservableCollection<IMenuItem>
            {
                votingViewModel,
                dashboardViewModel,
            };
            SelectedItem = MenuItems[0];
        }
    }
}
