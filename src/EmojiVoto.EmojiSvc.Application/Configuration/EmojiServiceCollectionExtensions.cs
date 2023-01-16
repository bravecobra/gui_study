using EmojiVoto.EmojiSvc.Application.Services;
using EmojiVoto.EmojiSvc.Application.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace EmojiVoto.EmojiSvc.Application.Configuration
{
    public static class EmojiServiceCollectionExtensions
    {
        public static IServiceCollection AddEmojiSvcApplication(this IServiceCollection services)
        {
            services.AddTransient<IEmojiService, EmojiService>();
            return services;
        }
    }
}
