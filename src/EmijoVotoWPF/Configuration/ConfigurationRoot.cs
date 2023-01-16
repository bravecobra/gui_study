using EmojiVoto.EmojiSvc.Api.Configuration;
using EmojiVoto.EmojiSvc.Application.Configuration;
using EmojiVoto.EmojiSvc.Persistence.Configuration;
using EmojiVoto.Voting.Api.Configuration;
using EmojiVoto.Voting.Application.Configuration;
using EmojiVoto.Voting.Persistence.Configuration;
using EmojiVotoWPF.Dashboard.Model;
using EmojiVotoWPF.Dashboard.ViewModel;
using EmojiVotoWPF.MainWindow;
using EmojiVotoWPF.Voting.Model;
using EmojiVotoWPF.Voting.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddTransient<IMainWindowViewModel, MainWindow.MainWindowViewModel>();
            services.AddTransient<MainWindow.MainWindow>();

            //EmojiSvc
            services.AddEmojiSvcApi();
            services.AddEmojiSvcApplicationServices();
            services.AddEmojiSvcSqlite(context.Configuration);

            //EmojiVoting
            services.AddEmojiVotingApi();
            services.AddEmojiVotingApplicationServices();
            services.AddEmojiVotingSqlite(context.Configuration);
            return services;
        }
    }
}
