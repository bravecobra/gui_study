using System.Windows;
using MaterialDesignThemes.Wpf;
using System;

namespace EmojiVotoWPF.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class MainWindow : Window
    {
        public MainWindow(IMainWindowViewModel model)
        {
            DataContext = model;
            InitializeComponent();
        }
    }
}
