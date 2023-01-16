using EmojiVoto.Voting.Application.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace EmojiVoto.Voting.Application.Configuration
{
    public static class EmojiVotingCollectionExtensions
    {
        public static IServiceCollection AddEmojiVotingApplication(this IServiceCollection services)
        {
            services.AddTransient<IVotingService, VotingService>();
            return services;
        }
    }
}
