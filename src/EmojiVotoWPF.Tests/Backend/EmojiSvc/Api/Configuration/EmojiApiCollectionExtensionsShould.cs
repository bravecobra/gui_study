using AutoMapper;
using EmojiVoto.EmojiSvc.Api.Configuration;
using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVoto.EmojiSvc.Application.Configuration;
using EmojiVoto.EmojiSvc.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace EmojiVotoGUI.Tests.Backend.EmojiSvc.Api.Configuration;

public class EmojiApiCollectionExtensionsShould
{
    [Fact]
    public void RegisterMediatrHandlers()
    {
        var mock = new Mock<IEmojiRepository>();
        var services = new ServiceCollection();
        services.AddEmojiSvcApi();
        services.AddEmojiSvcApplication();
        services.AddTransient(_ => mock.Object);

        var sut = services.BuildServiceProvider();

        var handler = sut.GetRequiredService<IRequestHandler<FindByShortCodeHandler.FindByShortcodeQuery, EmojiDto>>();
        Assert.NotNull(handler);
    }

    [Fact]
    public void RegisterAutomapperHandlers()
    {
        var services = new ServiceCollection();
        services.AddEmojiSvcApi();
        var sut = services.BuildServiceProvider();

        var mapper = sut.GetRequiredService<IMapper>();
        Assert.NotNull(mapper);
    }
}