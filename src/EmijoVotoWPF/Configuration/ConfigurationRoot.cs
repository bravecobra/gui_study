using System;
using System.Reflection;
using System.Windows;
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
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

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
            services.AddMediatR(Assembly.GetAssembly(typeof(DashboardViewModel))!);
            services.AddSingleton(typeof(Notifier), _ =>
            {
                return new Notifier(cfg =>
                {
                    cfg.PositionProvider = new WindowPositionProvider(
                        parentWindow: Application.Current.MainWindow,
                        corner: Corner.TopRight,
                        offsetX: 10,
                        offsetY: 10);

                    cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                        notificationLifetime: TimeSpan.FromSeconds(3),
                        maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                    cfg.Dispatcher = Application.Current.Dispatcher;
                });
            });
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
