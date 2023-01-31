using AutoMapper;
using EmojiVoto.EmojiSvc.Api;
using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVoto.EmojiSvc.Application.Services;
using EmojiVoto.EmojiSvc.Domain;
using Moq;

namespace EmojiVotoGUI.Tests.Backend.EmojiSvc.Api.Queries
{
    public class FindByShortCodeHandlerShould
    {
        [Fact]
        public async Task FindEnEmoji_GivenAShortCode()
        {
            const string shortCode = "something";
            const string uniCode = "unicode";
            var emoji = new EmojiVoto.EmojiSvc.Domain.Emoji
            {
                Shortcode = shortCode,
                Unicode = uniCode
            };
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(typeof(EmojiProfile)));
            var mapper = new Mapper(configuration);
            var service = new Mock<IEmojiService>();
            service.Setup(emojiService => emojiService.FindByShortCode(It.Is<string>(s => s == shortCode)))
                .ReturnsAsync(() => emoji);
            var sut = new FindByShortCodeHandler(service.Object, mapper);
            var request = new FindByShortCodeHandler.FindByShortcodeQuery()
            {
                ShortCode = shortCode
            };
            var result = await sut.Handle(request, CancellationToken.None);
            Assert.NotNull(result);
            service.Verify(emojiService => emojiService.FindByShortCode(It.Is<string>(s => s == shortCode)), 
                Times.Once);
        }
    }
}
