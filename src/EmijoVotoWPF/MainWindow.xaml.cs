using System.Windows;
using EmojiVotoWPF.Voting.ViewModel;

namespace EmojiVotoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IVotingViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
