using EmojiVoto.Voting.Application;
using EmojiVoto.Voting.Persistence.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmojiVoto.Voting.Persistence.Configuration
{
    public static class EmojiVotingCollectionExtensions
    {
        public static IServiceCollection AddEmojiVotingSqlite(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IVotingRepository, VotingRepository>();
            services.AddDbContext<VotingDbContext>(builder =>
            {
                builder.UseSqlite(configuration.GetConnectionString("DefaultConnectionVoting"));
                builder.EnableSensitiveDataLogging();
            });
            return services;
        }
    }
}
