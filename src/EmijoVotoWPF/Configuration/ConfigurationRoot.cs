using EmojiVoto.EmojiSvc.Api.Configuration;
using EmojiVoto.EmojiSvc.Application.Configuration;
using EmojiVoto.EmojiSvc.Persistence.Configuration;
using EmojiVoto.Voting.Api.Configuration;
using EmojiVoto.Voting.Application.Configuration;
using EmojiVoto.Voting.Persistence.Configuration;
using EmojiVotoWPF.Dashboard.Model;
using EmojiVotoWPF.Dashboard.ViewModel;
using EmojiVotoWPF.Events;
using EmojiVotoWPF.MainWindow;
using EmojiVotoWPF.Voting.Model;
using EmojiVotoWPF.Voting.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notifications.Wpf.Core;

namespace EmojiVotoWPF.Configuration
{
    internal static class ConfigurationRoot
    {
        public static IServiceCollection AddConfigurationRoot(this IServiceCollection services, HostBuilderContext context)
        {
            //UI
            services.AddTransient<IVotingViewModel, VotingViewModel>();
            services.AddTransient<IVotingModel, VotingModel>();
            services.AddTransient<IDashboardViewModel, DashboardViewModel>();
            services.AddTransient<IDashboardModel, DashboardModel>();
            services.AddTransient<IMainWindowViewModel, MainWindowViewModel>();
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(App).Assembly));
            services.AddSingleton<INewVoteCollector, VoteEventSubject>();
            services.AddTransient<INotificationManager, NotificationManager>();
            services.AddTransient<MainWindow.MainWindow>();

            //EmojiSvc
            services.AddEmojiSvcApi();
            services.AddEmojiSvcApplication();
            services.AddEmojiSvcSqlite(context.Configuration);

            //EmojiVoting
            services.AddEmojiVotingApi();
            services.AddEmojiVotingApplication();
            services.AddEmojiVotingSqlite(context.Configuration);
            return services;
        }
    }
}
