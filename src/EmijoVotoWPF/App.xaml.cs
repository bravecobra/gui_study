using System.Windows;
using EmojiVotoWPF.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmojiVotoWPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = ConfigurationRoot.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    }
}