using EmojiVoto.EmojiSvc.Application.Configuration;
using EmojiVoto.EmojiSvc.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace EmojiVotoGUI.Tests.Backend.EmojiSvc.Application;

public class EmojiServiceCollectionExtensionsShould
{
    [Fact]
    public async Task RegisterTheEmojiService()
    {
        var mock = new Mock<IEmojiRepository>();

        var services = new ServiceCollection();
        services.AddEmojiSvcApplication();
        services.AddTransient<IEmojiRepository>(_ => mock.Object);
        var serviceProvider = services.BuildServiceProvider();

        var emojiService = serviceProvider.GetService<IEmojiService>();

        Assert.True(emojiService != null);

    }
}