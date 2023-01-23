using AutoMapper;
using EmojiVoto.EmojiSvc.Api;
using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVoto.EmojiSvc.Application.Services;
using EmojiVoto.EmojiSvc.Domain;
using Moq;

namespace EmojiVotoGUI.Tests.Backend.EmojiSvc.Api.Queries;

public class ListAllEmojisHandlerShould
{
    [Fact]
    public async Task ResultAListOfEmojiDtos()
    {
        var configuration = new MapperConfiguration(cfg =>
            cfg.AddProfile(typeof(EmojiProfile)));
        var mapper = new Mapper(configuration);
        var service = new Mock<IEmojiService>();
        service.Setup(emojiService => emojiService.ListEmojis()).ReturnsAsync(() => new List<Emoji>());
        var sut = new ListAllEmojisHandler(service.Object, mapper);
        var request = new ListAllEmojisHandler.ListAllEmojis();
        var result = await sut.Handle(request, CancellationToken.None);
        Assert.NotNull(result);
        service.Verify(emojiService => emojiService.ListEmojis(), Times.Once);
    }
}