using System;
using System.Windows;
using EmojiVoto.EmojiSvc.Persistence;
using EmojiVoto.Voting.Persistence;
using EmojiVotoWPF.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmojiVotoWPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddConfigurationRoot(context);
            })
            .Build();

        //Migrate emojiDb
        using var scopeEmojies = _host.Services.CreateScope();
        var emojiDb = scopeEmojies.ServiceProvider.GetRequiredService<EmojiDbContext>();
        emojiDb.Database.Migrate();

        //Migrate votingDb
        using var scopeVoting = _host.Services.CreateScope();
        var votingDb = scopeVoting.ServiceProvider.GetRequiredService<VotingDbContext>();
        votingDb.Database.Migrate();

    }

    private async void Application_Startup(object sender, StartupEventArgs e)
    {
        await _host.StartAsync();
        var mainWindow = _host.Services.GetRequiredService<MainWindow.MainWindow>();
        mainWindow.Show();
    }

    private async void Application_Exit(object sender, ExitEventArgs e)
    {
        using (_host)
        {
            await _host.StopAsync(TimeSpan.FromSeconds(5));
        }
    }
}