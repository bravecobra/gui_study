using EmojiVoto.EmojiSvc.Application.Services;
using EmojiVoto.EmojiSvc.Persistence.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmojiVoto.EmojiSvc.Persistence.Configuration
{
    public static class EmojiServiceCollectionExtensions
    {
        public static IServiceCollection AddEmojiSvcSqlite(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmojiRepository, DatabaseEmojiRepository>();
            services.AddDbContext<EmojiDbContext>(builder =>
            {
                builder.UseSqlite(configuration.GetConnectionString("DefaultConnectionEmojies"));
                builder.EnableSensitiveDataLogging();
            });
            return services;
        }
    }
}
