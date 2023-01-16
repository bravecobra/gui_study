using System.Reflection;
using EmojiVoto.Voting.Api.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EmojiVoto.Voting.Api.Configuration
{
    public static class EmojiApiCollectionExtensions
    {
        public static IServiceCollection AddEmojiVotingApi(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(VotingProfile)));
            services.AddMediatR(Assembly.GetAssembly(typeof(VoteEmojiHandler))!);
            return services;
        }
    }
}
