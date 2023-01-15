using System.Windows;
using EmojiVotoWPF.Voting.ViewModel;

namespace EmojiVotoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IVotingViewModel _model;
        public MainWindow(IVotingViewModel model)
        {
            InitializeComponent();
            _model = model;
            DataContext = _model;
        }

        private void VotingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _model.GetEmojies();
        }
    }
}
