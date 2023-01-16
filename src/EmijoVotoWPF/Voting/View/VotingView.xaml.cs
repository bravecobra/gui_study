using EmojiVotoWPF.Voting.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EmojiVotoWPF.Voting.View
{
    /// <summary>
    /// Interaction logic for VotingView.xaml
    /// </summary>
    public partial class VotingView : UserControl
    {
        public VotingView()
        {
            InitializeComponent();
        }

        private void VotingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as IVotingViewModel)?.GetEmojies(); //refresh when load
        }
    }
}
