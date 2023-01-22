using System.Collections.ObjectModel;
using EmojiVoto.EmojiSvc.Application.Services;
using EmojiVoto.EmojiSvc.Application.Services.Impl;
using EmojiVoto.EmojiSvc.Domain;
using Moq;

namespace EmojiVotoGUI.Tests.Backend.EmojiSvc.Application
{
    public class EmojiServiceShould
    {
        [Fact]
        public async Task ReturnAnEmojiWhenCallingFindByShortCode_GivenShortCode()
        {
            var shortCode = "something";
            var uniCode = "unicode";
            var emoji = new Emoji()
            {
                Shortcode = shortCode, 
                Unicode = uniCode
            };
            var repositoryMock = new Mock<IEmojiRepository>();
            repositoryMock.Setup(repository => repository.Get(It.IsAny<string>())).ReturnsAsync(() => emoji);
            var sut = new EmojiService(repositoryMock.Object);
            string emojiShortCode = shortCode;
            var result = await sut.FindByShortCode(emojiShortCode);
            Assert.True(result != null);
            repositoryMock.Verify(repository =>  repository.Get(shortCode), Times.Once());
            Assert.Equal(shortCode, result.Shortcode);
            Assert.Equal(uniCode, result.Unicode);
        }

        [Fact]
        public async Task ReturnAListOfEmojisWhenCallingListEmojis()
        {
            //Arrange
            var shortCode = "something";
            var emoji = new Emoji()
            {
                Shortcode = shortCode,
                Unicode = shortCode
            };
            var repositoryMock = new Mock<IEmojiRepository>();
            repositoryMock.Setup(repository => repository.List()).ReturnsAsync(() => new ReadOnlyCollection<Emoji>(new List<Emoji>{ emoji }));
            var sut = new EmojiService(repositoryMock.Object);

            //Act
            string emojiShortCode = shortCode;
            var result = await sut.ListEmojis();

            //Assert
            Assert.True(result != null);
            repositoryMock.Verify(repository => repository.List(), Times.Once());
        }
    }
}
