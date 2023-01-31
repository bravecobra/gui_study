using EmojiVoto.EmojiSvc.Persistence.Impl;

namespace EmojiVotoGUI.Tests.Backend.EmojiSvc.Persistence
{
    public class EmojiRepositoryShould: IClassFixture<EmojiDbFixture>
    {
        private readonly EmojiDbFixture _fixture;

        public EmojiRepositoryShould(EmojiDbFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetAllEmojis()
        {
            var sut = new DatabaseEmojiRepository(_fixture.Context);
            var result = await sut.List();
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetAnEmoji()
        {
            const string shortcode = "shortcode1";
            var sut = new DatabaseEmojiRepository(_fixture.Context);
            var result = await sut.Get(shortcode);
            Assert.NotNull(result);
            Assert.Equal("unicode1", result.Unicode);
        }
    }
}
