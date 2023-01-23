using EmojiVoto.EmojiSvc.Application.Configuration;
using EmojiVoto.EmojiSvc.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace EmojiVotoGUI.Tests.Backend.EmojiSvc.Application.Configuration;

public class EmojiServiceCollectionExtensionsShould
{
    [Fact]
    public void RegisterTheEmojiService()
    {
        var mock = new Mock<IEmojiRepository>();

        var services = new ServiceCollection();
        services.AddEmojiSvcApplication();
        services.AddTransient(_ => mock.Object);
        var serviceProvider = services.BuildServiceProvider();

        var emojiService = serviceProvider.GetService<IEmojiService>();

        Assert.NotNull(emojiService);
    }
}