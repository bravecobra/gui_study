using System;
using EmojiVotoWPF.Voting.Model;
using EmojiVotoWPF.Voting.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmojiVotoWPF.Configuration
{
    internal static class ConfigurationRoot
    {
        private static IServiceProvider? _serviceProvider;

        public static IServiceProvider Services => _serviceProvider ??= Run();

        private static IServiceProvider Run()
        {
            var services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });
            services.AddTransient<IVotingViewModel, VotingViewModel>();
            services.AddTransient<IVotingModel, VotingModel>();
            services.AddTransient<MainWindow>();
            return services.BuildServiceProvider();
        }
    }
}
