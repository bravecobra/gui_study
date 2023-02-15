using System.Reflection;
using EmojiVoto.EmojiSvc.Api.Queries;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace EmojiVoto.EmojiSvc.Api.Configuration
{
    public static class EmojiApiCollectionExtensions
    {
        public static IServiceCollection AddEmojiSvcApi(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(EmojiProfile)));
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(typeof(ListAllEmojisHandler).Assembly));
            return services;
        }
    }
}
