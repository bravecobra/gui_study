using System.Windows;
using System.Windows.Controls;
using EmojiVotoWPF.Dashboard.ViewModel;

namespace EmojiVotoWPF.Dashboard.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class DashboardView : UserControl
    {
 
        public DashboardView(IDashboardViewModel model)
        {
            DataContext = model;
            InitializeComponent();
        }

        public DashboardView()
        {
            InitializeComponent();
        }

        private void DashboardView_OnLoaded(object sender, RoutedEventArgs e)
        {
            (DataContext as IDashboardViewModel)?.GetResults();
        }
    }
}
