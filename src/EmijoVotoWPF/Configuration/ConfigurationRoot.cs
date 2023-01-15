using System;
using Microsoft.Extensions.DependencyInjection;

namespace EmojiVotoWPF.Configuration
{
    internal static class ConfigurationRoot
    {
        private static IServiceProvider? _serviceProvider;

        public static IServiceProvider Services => _serviceProvider ??= Run();

        private static IServiceProvider Run()
        {
            var services = new ServiceCollection();
            services.AddTransient<MainWindow>();
            return services.BuildServiceProvider();
        }
    }
}
