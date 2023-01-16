using System;
using System.Windows;
using EmojiVoto.EmojiSvc.Persistence;
using EmojiVoto.Voting.Persistence;
using EmojiVotoWPF.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmojiVotoWPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;
    // private readonly IConfiguration _settings;

    public App()
    {
        _host = new HostBuilder()
            .ConfigureAppConfiguration((context, configurationBuilder) =>
            {
                configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                configurationBuilder.AddJsonFile("appsettings.json", optional: false);
            })
            .ConfigureLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            })
            .ConfigureServices((context, services) =>
            {
                services.AddConfigurationRoot(context);
            })
            .Build();

        using var scopeEmojies = _host.Services.CreateScope();
        var emojiDb = scopeEmojies.ServiceProvider.GetRequiredService<EmojiDbContext>();
        emojiDb.Database.Migrate();
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